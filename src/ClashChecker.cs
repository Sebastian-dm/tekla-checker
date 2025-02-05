using System;
using System.Collections;
using System.Collections.Generic;
using Tekla.Structures.Geometry3d;
using Tekla.Structures.Model;
using ModelObjectSelector = Tekla.Structures.Model.UI.ModelObjectSelector;

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
        #endregion


        public bool ClashCheck(double minOverlap)
        {

            SettingMinOverlap = minOverlap;


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

        #region events
        private void TsEventOnClashDetected(ClashCheckData clashCheckData) {
            lock (_eventLock)
                if (clashCheckData.Overlap >= 0)//SettingMinOverlap)
                    _clashData.Add(clashCheckData);
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

