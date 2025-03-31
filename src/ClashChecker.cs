using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;


using Tekla.Structures.Geometry3d;
using Tekla.Structures.Model;

using ModelObjectSelector = Tekla.Structures.Model.UI.ModelObjectSelector;
using Tekla.Structures;
using Tekla.Structures.ModelInternal;
using System.Linq;

namespace TeklaChecker
{
    /// <summary>
    /// This example shows how to run Clash Check and use related events from Tekla OpenAPI.
    /// </summary>
    public class ClashChecker
    {
        #region fields & properties
        private readonly Model _model = new Model();
        private ModelObjectSelector _selector;
        private ClashCheckHandler _clashCheckHandler;

        // Status indicators
        private bool _clashCheckInProgress = false;

        // Events
        protected Events TsEvent;
        private readonly object _eventLock = new object();

        // Tread wait time settings
        private const int WaitInterval = 1500;
        private const int MaxWaitSeconds = 30;

        // Clash data
        private List<ClashCheckData> _clashData;
        public List<ClashCheckData> ClashData { get { return _clashData; } }


        private double SettingMinOverlap = 0.00;

        private HashSet<double> _overlap = new HashSet<double>();

        private const string _jsonPath = "C:\\Users\\sdme\\git\\tekla-checker\\src\\Resources\\clash_rules.json";
        private Dictionary<string, Dictionary<string, Dictionary<string, string>>> _clashConfig;
        #endregion


        public bool ClashCheck(double minOverlap)
        {
            SettingMinOverlap = minOverlap;
            _clashConfig = LoadClashConfig(_jsonPath);

            bool result = false;
            _selector = new ModelObjectSelector();
            _clashData = new List<ClashCheckData>();
            ArrayList objectsToSelect = new ArrayList();

            var mos = _model.GetModelObjectSelector();
            var moe = mos.GetObjectsByFilterName("ClashCheck");

            while (moe.MoveNext()) {
                ModelObject modelObject = moe.Current;
                if (modelObject != null) {
                    objectsToSelect.Add(modelObject);
                }
            }

            _selector.Select(objectsToSelect);
            _model.CommitChanges();

            RegisterEvents();
            result = RunClashCheck();
            DeregisterEvents();

            return result;
        }

        private Dictionary<string, Dictionary<string, Dictionary<string, string>>> LoadClashConfig(string jsonPath) {
            var result = new Dictionary<string, Dictionary<string, Dictionary<string, string>>>();

            string json = File.ReadAllText(jsonPath);
            var doc = JsonDocument.Parse(json);
            var root = doc.RootElement;

            foreach (var firstLevel in root.EnumerateObject()) {
                string firstKey = firstLevel.Name;
                result[firstKey] = new Dictionary<string, Dictionary<string, string>>();

                foreach (var secondLevel in firstLevel.Value.EnumerateObject()) {
                    string secondKey = secondLevel.Name;
                    var innerDict = new Dictionary<string, string>();

                    foreach (var innerProp in secondLevel.Value.EnumerateObject()) {
                        innerDict[innerProp.Name] = innerProp.Value.ToString();
                    }

                    result[firstKey][secondKey] = innerDict;
                }
            }
            return result;
        }

        #region events
        private void TsEventOnClashDetected(ClashCheckData clashCheckData) {
            lock (_eventLock) {
                var model = new Model();
                string part1Name = "";
                string part2Name = "";
                Part Part1 = model.GetCorrectInstance(clashCheckData.Object1.Identifier) as Part;
                Part Part2 = model.GetCorrectInstance(clashCheckData.Object2.Identifier) as Part;
                Part1.GetReportProperty("NAME", ref part1Name);
                Part2.GetReportProperty("NAME", ref part2Name);
                
                if (isNotIgnored(part1Name, part2Name)) {
                    _clashData.Add(clashCheckData);
                    _overlap.Add(clashCheckData.Overlap);
                }
            }
        }

        private bool isNotIgnored(string part1Name, string part2Name) {
            Dictionary<string, string> matchingConfig = GetMatchingConfigLine(part1Name, part2Name, StringComparison.OrdinalIgnoreCase);
            if (matchingConfig.ContainsKey("type") && matchingConfig["type"] != "ignore")
                return true;
            else
                return false;
        }

        private Dictionary<string, string> GetMatchingConfigLine(string part1Name, string part2Name, StringComparison comparisonType = StringComparison.Ordinal) {
            string[,] partNames = {{part1Name, part2Name},{part2Name, part1Name}};
            
            foreach (string configPartName1 in _clashConfig.Keys) {
                for (int i = 0; i < 2; i++) {
                    if (IsMatchingWildcardString(partNames[i, 0], pattern: configPartName1, comparisonType)) {
                        foreach (string configPartName2 in _clashConfig[configPartName1].Keys) {
                            if (IsMatchingWildcardString(partNames[i, 1], pattern: configPartName2, comparisonType)) {
                                return _clashConfig[configPartName1][configPartName2];
                            }
                        }
                    }
                }
            }
            return new Dictionary<string, string>() { { "type" , "clash" },{ "max_overlap", "10" }  };
        }

        private bool IsMatchingWildcardString(string partName, string pattern, StringComparison comparisonType = StringComparison.Ordinal) {
            if (pattern == "*") return true;
            if (pattern.StartsWith("*")) return partName.EndsWith(pattern.Trim('*'));
            if (pattern.EndsWith("*")) return partName.StartsWith(pattern.Trim('*'));
            return partName.Equals(pattern, comparisonType);
        }

        private void TsEventOnClashCheckDone(int numberClashes) {
            lock (_eventLock) {
                System.Threading.Thread.Sleep(WaitInterval);
                _clashCheckInProgress = false;
            }
        }

        private void RegisterEvents() {
            try {
                _clashCheckHandler = _model.GetClashCheckHandler();
                TsEvent = new Events();
                TsEvent.ClashDetected += TsEventOnClashDetected;
                TsEvent.ClashCheckDone += TsEventOnClashCheckDone;
                TsEvent.Register();
            }
            catch (ApplicationException Exc) {
                Console.WriteLine("Exception: " + Exc.ToString());
            }
        }
        private void DeregisterEvents() {
            if (TsEvent != null)
                TsEvent.UnRegister();
        }
        #endregion


        private bool RunClashCheck()
        {
            _clashCheckInProgress = true;
            _clashData.Clear();

            DateTime start = DateTime.Now;
            _clashCheckHandler.RunClashCheckWithOptions(
                betweenReferenceModels: false,
                betweenReferenceModelsAndComponents: false,
                objectsInsideReferenceModels: false,
                minDistance: SettingMinOverlap,
                betweenParts: true);

            TimeSpan span = new TimeSpan();

            while (_clashCheckInProgress && span.TotalSeconds < MaxWaitSeconds)
            {
                System.Threading.Thread.Sleep(WaitInterval);
                DateTime end = DateTime.Now;
                span = end.Subtract(start);
            }
            return true;
        }
    }
}

