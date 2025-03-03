using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tekla.Structures;
using Tekla.Structures.Model;
using Tekla.Structures.Geometry3d;
using TSMUI = Tekla.Structures.Model.UI;
using Tekla.Structures.Solid;
using Tekla.Structures.Model.UI;
using Tekla.Structures.ModelInternal;




namespace TeklaChecker {
    internal class ViewHelper {

        private static readonly ClashCheckHandler _ClashCheckHandler = new Model().GetClashCheckHandler();


        private static List<int> _temporaryGraphicIds = new List<int>();



        public void ZoomToPart(Part part) {
            AABB PartBoundingBox = new AABB();

            if (part != null) {
                Solid PartSolid = part.GetSolid();
                PartBoundingBox.MaxPoint = PartSolid.MaximumPoint;
                PartBoundingBox.MinPoint = PartSolid.MinimumPoint;
            }

            TSMUI.ModelViewEnumerator ViewEnum = TSMUI.ViewHandler.GetVisibleViews();

            while (ViewEnum.MoveNext()) {
                TSMUI.View ViewSel = ViewEnum.Current;
                TSMUI.ViewHandler.ZoomToBoundingBox(ViewSel, PartBoundingBox);
            }
        }

        public void ZoomToParts(Part[] parts) {
            
            // Find bounding coordinates
            Solid PartSolid;



            double Xmin = double.PositiveInfinity, Xmax = double.NegativeInfinity;
            double Ymin = double.PositiveInfinity, Ymax = double.NegativeInfinity;
            double Zmin = double.PositiveInfinity, Zmax = double.NegativeInfinity;
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
            TSMUI.ModelViewEnumerator ViewEnum = TSMUI.ViewHandler.GetVisibleViews();
            while (ViewEnum.MoveNext()) {
                TSMUI.View ViewSel = ViewEnum.Current;
                TSMUI.ViewHandler.ZoomToBoundingBox(ViewSel, PartBoundingBox);
            }
        }

        public void HighlightObjects(int ID1, int ID2) {
            ArrayList boundingBoxes;
            Identifier identifier1 = new Identifier(ID1);
            Identifier identifier2 = new Identifier(ID2);

            try {
                boundingBoxes = GetIntersectionMinimumIntersectionBoundingBoxes(identifier1, identifier2);
            }
            catch (ArgumentException) {
                // Not all object types are visualizable. Just draw nothing.
                return;
            }

            var graphicsDrawer = new TSMUI.GraphicsDrawer();

            foreach (AABB boundingBox in boundingBoxes) {
                var graphicPolyLine = new TSMUI.GraphicPolyLine(
                    color: new TSMUI.Color(1.0, 0.0, 1.0),
                    width: 4,
                    type: TSMUI.GraphicPolyLine.LineType.Solid
                );
                graphicPolyLine.PolyLine = BoundingBoxToPolyline(boundingBox);
                int id = graphicsDrawer.DrawPolyLine(graphicPolyLine);
                _temporaryGraphicIds.Add(id);
            }
        }

        public void RemoveHighlights() {
            var graphicsDrawer = new TSMUI.GraphicsDrawer();
            graphicsDrawer.RemoveTemporaryGraphicsObjects(_temporaryGraphicIds);
            _temporaryGraphicIds.Clear();
        }

        private PolyLine BoundingBoxToPolyline(AABB boundingBox) {
            Point pmin = boundingBox.MinPoint;
            Point pmax = boundingBox.MaxPoint;

            ArrayList points = new ArrayList() {
                // Bottom loop
                pmin,new Point(pmin.X, pmin.Y, pmax.Z),pmin,
                new Point(pmin.X, pmax.Y, pmin.Z),new Point(pmin.X, pmax.Y, pmax.Z),new Point(pmin.X, pmax.Y, pmin.Z),
                new Point(pmax.X, pmax.Y, pmin.Z),new Point(pmax.X, pmax.Y, pmax.Z),new Point(pmax.X, pmax.Y, pmin.Z),
                new Point(pmax.X, pmin.Y, pmin.Z),new Point(pmax.X, pmin.Y, pmax.Z),new Point(pmax.X, pmin.Y, pmin.Z),
                pmin,
                // Upper loop
                new Point(pmin.X, pmin.Y, pmax.Z),
                new Point(pmin.X, pmax.Y, pmax.Z),
                new Point(pmax.X, pmax.Y, pmax.Z),
                new Point(pmax.X, pmin.Y, pmax.Z),
                new Point(pmin.X, pmin.Y, pmax.Z),
            };

            return new PolyLine(points);
        }

        private ArrayList GetIntersectionMinimumIntersectionBoundingBoxes(Identifier identifier1, Identifier identifier2) {
            var orientedBoundingBoxes = new ArrayList();

            Part Part1 = new Model().GetCorrectInstance(identifier1) as Part;
            Part Part2 = new Model().GetCorrectInstance(identifier2) as Part;
            Solid Solid1 = Part1.GetSolid();
            Solid Solid2 = Part2.GetSolid();

            //var MyModel = new Model();
            //MyModel.GetWorkPlaneHandler().SetCurrentTransformationPlane(new TransformationPlane());
            //MyModel.GetWorkPlaneHandler().SetCurrentTransformationPlane(new TransformationPlane(Part1.GetCoordinateSystem()));
            //Part1.Select();

            ArrayList ClashBoxes;
            try {
                ClashBoxes = _ClashCheckHandler.GetIntersectionBoundingBoxes(identifier1, identifier2);
                
            }
            catch (ArgumentException) {
                // Not all object types are visualizable. Just draw nothing.
                return new ArrayList();
            }


            Part a = new Model().GetCorrectInstance(identifier1) as Part;
            a.Select();

            

            foreach (AABB ClashBox in ClashBoxes) {
                AABB ClashBoxNew = new AABB();
                ClashBoxNew.MinPoint.X = Math.Max(Math.Max(ClashBox.MinPoint.X, Solid1.MinimumPoint.X), Solid2.MinimumPoint.X);
                ClashBoxNew.MinPoint.Y = Math.Max(Math.Max(ClashBox.MinPoint.Y, Solid1.MinimumPoint.Y), Solid2.MinimumPoint.Y);
                ClashBoxNew.MinPoint.Z = Math.Max(Math.Max(ClashBox.MinPoint.Z, Solid1.MinimumPoint.Z), Solid2.MinimumPoint.Z);
                ClashBoxNew.MaxPoint.X = Math.Min(Math.Min(ClashBox.MaxPoint.X, Solid1.MaximumPoint.X), Solid2.MaximumPoint.X);
                ClashBoxNew.MaxPoint.Y = Math.Min(Math.Min(ClashBox.MaxPoint.Y, Solid1.MaximumPoint.Y), Solid2.MaximumPoint.Y);
                ClashBoxNew.MaxPoint.Z = Math.Min(Math.Min(ClashBox.MaxPoint.Z, Solid1.MaximumPoint.Z), Solid2.MaximumPoint.Z);
                orientedBoundingBoxes.Add(ClashBoxNew);
            }

            return orientedBoundingBoxes;
        }
    }
}
