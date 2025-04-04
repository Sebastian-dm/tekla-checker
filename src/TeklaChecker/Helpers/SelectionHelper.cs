using System;
using System.Collections;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using Tekla.Structures.Model;

using ModelObjectSelector = Tekla.Structures.Model.UI.ModelObjectSelector;

namespace TeklaChecker.Helpers {
    internal class SelectionHelper {

        private Model _model;
        private ModelObjectSelector _selector;


        public SelectionHelper() {
            _model = new Model();
            _selector = new ModelObjectSelector();
        }

        public List<Part> GetSelectedParts() {

            List<Part> selectedParts = new List<Part>();

            ModelObjectEnumerator moe = new ModelObjectSelector().GetSelectedObjects();
            moe.SelectInstances = true;

            while (moe.MoveNext()) {
                ModelObject modelObject = moe.Current;
                if (modelObject != null && modelObject is Part) {
                    selectedParts.Add((Part)modelObject);
                }
            }

            return selectedParts;
        }

        public List<Part> GetAllParts(Model model) {

            Type[] Types = new Type[1];
            Types.SetValue(typeof(Part), 0);

            ModelObjectEnumerator moe = model.GetModelObjectSelector().GetAllObjectsWithType(Types);
            moe.SelectInstances = true;

            Part[] allParts = new Part[moe.GetSize()];
            for (int i = 0; i < moe.GetSize();i++)
                allParts[i] = (Part)moe.Current;

            return allParts.ToList();
        }

        public void SelectParts(Part[] parts) {
            ArrayList modelObjects = new ArrayList();
            foreach (Part part in parts) {
                modelObjects.Add(part);
            }

            _selector.Select(modelObjects);
            _model.CommitChanges();

        }
    }
}
