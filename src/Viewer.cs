using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tekla.Structures.Model;
using Tekla.Structures.Model.UI;
using Tekla.Structures.Geometry3d;

namespace TeklaChecker {
    internal class Viewer {

        public void ZoomToPart(Part part) {
            AABB PartBoundingBox = new AABB();

            if (part != null) {
                Solid PartSolid = part.GetSolid();
                PartBoundingBox.MaxPoint = PartSolid.MaximumPoint;
                PartBoundingBox.MinPoint = PartSolid.MinimumPoint;
            }

            ModelViewEnumerator ViewEnum = ViewHandler.GetVisibleViews();

            while (ViewEnum.MoveNext()) {
                View ViewSel = ViewEnum.Current;
                ViewHandler.ZoomToBoundingBox(ViewSel, PartBoundingBox);
            }
        }

        public void ZoomToParts(Part[] parts) {
            
            // Find bounding coordinates
            Solid PartSolid;
            double Xmin = 0, Xmax = 0;
            double Ymin = 0, Ymax = 0;
            double Zmin = 0, Zmax = 0;
            foreach (Part part in parts) {
                if (part == null) continue;
                PartSolid = part.GetSolid();
                Xmin = Math.Min(Xmin, PartSolid.MinimumPoint.X);
                Xmax = Math.Max(Xmax, PartSolid.MaximumPoint.X);
                Ymin = Math.Min(Ymin, PartSolid.MinimumPoint.Y);
                Ymax = Math.Max(Ymax, PartSolid.MaximumPoint.Y);
                Zmin = Math.Min(Zmin, PartSolid.MinimumPoint.Z);
                Zmax = Math.Max(Zmax, PartSolid.MaximumPoint.Z);
            }

            // Set up bounding box
            AABB PartBoundingBox = new AABB();
            PartBoundingBox.MaxPoint = new Point(Xmax, Ymax, Zmax);
            PartBoundingBox.MinPoint = new Point(Xmin, Ymin, Zmin);

            // Set view
            ModelViewEnumerator ViewEnum = ViewHandler.GetVisibleViews();
            while (ViewEnum.MoveNext()) {
                View ViewSel = ViewEnum.Current;
                ViewHandler.ZoomToBoundingBox(ViewSel, PartBoundingBox);
            }
        }

    }
}
