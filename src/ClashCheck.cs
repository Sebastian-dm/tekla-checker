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
    public class Checker
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
        private int _numberClashes;
        private ArrayList _clashTexts;
        public ArrayList ClashTexts { get { return _clashTexts; } }
        private List<ClashCheckData> _clashData;
        public List<ClashCheckData> ClashData { get { return _clashData; } }
        #endregion


        public bool ClashCheck()
        {
            bool result = false;
            _selector = new ModelObjectSelector();
            _clashData = new List<ClashCheckData>();
            _clashTexts = new ArrayList();
            ArrayList objectsToSelect = new ArrayList();

            var mos = _model.GetModelObjectSelector();
            var moe = mos.GetObjectsByFilterName("ClashCheck");
            moe.SelectInstances = true;

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
        private void TsEventOnClashDetected(ClashCheckData clashCheckData)
        {
            lock (_eventLock) {
                _clashData.Add(clashCheckData);
                _clashTexts.Add("Clash: " + clashCheckData.Object1.Identifier.ID + " <-> " + clashCheckData.Object2.Identifier.ID + ".");
                //_clashParts.Add(
                //    clashCheckData.Object1.Identifier.ID.ToString() + "-" + clashCheckData.Object2.Identifier.ID.ToString(),
                //    new Part[2] { (Part)clashCheckData.Object1, (Part)clashCheckData.Object2 });
                //_clashTexts.Add(
                //    ((Part)clashCheckData.Object1).Name +
                //    " " +
                //    ((Part)clashCheckData.Object2).Name +
                //    ": " +
                //    clashCheckData.Type.ToString());
            }
        }

        private void TsEventOnClashCheckDone(int numberClashes)
        {
            lock (_eventLock)
            {
                System.Threading.Thread.Sleep(WaitInterval);
                _numberClashes = numberClashes;
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
            _numberClashes = 0;
            _clashTexts.Clear();

            DateTime start = DateTime.Now;
            _clashCheckHandler.RunClashCheckWithOptions(
                betweenReferenceModels: false,
                objectsInsideReferenceModels: false,
                minDistance: 2.00,
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

