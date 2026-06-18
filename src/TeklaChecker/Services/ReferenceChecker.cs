using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Tekla.Structures.DrawingInternal;
using Tekla.Structures.Model;
using TSD = Tekla.Structures.Drawing;
using TSM = Tekla.Structures.Model;

namespace TeklaChecker.Services {
    internal class ReferenceChecker {

        public ReferenceChecker() {
            RunCheck();
        }

        public void RunCheck() {
            TSM.Operations.Operation.DisplayPrompt("Analyzing reference models of all selected drawings. Please wait ...");
            try {
                TSD.DrawingHandler drawingHandler = new TSD.DrawingHandler();

                // Get selected drawings
                TSD.DrawingEnumerator selectedDrawings = drawingHandler.GetDrawingSelector().GetSelected();

                if (selectedDrawings.GetSize() == 0) {
                    TSM.Operations.Operation.DisplayPrompt("No drawings selected. Please select drawings from Document Manager.");
                    return;
                }

                // Dictionary to store reference model visibility per drawing
                Dictionary<string, List<string>> drawingRefModels = new Dictionary<string, List<string>>();
                HashSet<string> allRefModels = new HashSet<string>();

                // Process each selected drawing
                while (selectedDrawings.MoveNext()) {
                    var currentDrawing = selectedDrawings.Current;
                    if (currentDrawing == null) continue;

                    string drawingKey = string.Format("{0} - {1}", currentDrawing.Mark, string.Join(", ", currentDrawing.Name,currentDrawing.Title1, currentDrawing.Title2, currentDrawing.Title3));
                    List<string> visibleRefModels = new List<string>();

                    // Get reference model visibility settings
                    TSD.DrawingObjectEnumerator views = currentDrawing.GetSheet().GetViews();

                    while (views.MoveNext()) {
                        var view = views.Current as TSD.View;
                        TSD.DrawingObjectEnumerator refObjs = view.GetModelObjects();
                        
                        while (refObjs.MoveNext()) {
                            var refObj = refObjs.Current as TSD.ReferenceModel;
                            if (refObj == null)
                                continue;

                            if (refObj.Hideable.IsHidden)
                                continue;
                            
                            string refModelName = GetReferenceModelName(refObj);
                            if (!string.IsNullOrEmpty(refModelName)) {
                                visibleRefModels.Add(refModelName);
                                allRefModels.Add(refModelName);
                            }
                        }
                    }

                    // Remove duplicates and sort
                    visibleRefModels = visibleRefModels.Distinct().OrderBy(x => x).ToList();
                    drawingRefModels[drawingKey] = visibleRefModels;
                }

                // Generate report
                StringBuilder report = new StringBuilder();
                report.AppendLine("========================================");
                report.AppendLine("REFERENCE MODEL VISIBILITY REPORT");
                report.AppendLine("========================================");
                report.AppendLine();
                report.AppendLine(string.Format("Total Drawings Analyzed: {0}", drawingRefModels.Count));
                report.AppendLine(string.Format("Unique Reference Models Found: {0}", allRefModels.Count));
                report.AppendLine();

                if (allRefModels.Count > 0) {
                    report.AppendLine("All Reference Models:");
                    foreach (string refModel in allRefModels.OrderBy(x => x)) {
                        report.AppendLine(string.Format("  - {0}", refModel));
                    }
                    report.AppendLine();
                }

                report.AppendLine("========================================");
                report.AppendLine("REFERENCE MODEL SUMMARY:");
                report.AppendLine("========================================");
                report.AppendLine();

                // Create summary showing which drawings contain each reference model
                foreach (string refModel in allRefModels.OrderBy(x => x)) {
                    List<string> drawingsWithRefModel = new List<string>();

                    foreach (var kvp in drawingRefModels) {
                        if (kvp.Value.Contains(refModel)) {
                            drawingsWithRefModel.Add(kvp.Key);
                        }
                    }

                    report.AppendLine(string.Format("Reference Model: {0}", refModel));
                    report.AppendLine(string.Format("  Appears in {0} drawing(s):", drawingsWithRefModel.Count));
                    foreach (string drawing in drawingsWithRefModel) {
                        report.AppendLine(string.Format("    - {0}", drawing));
                    }
                    report.AppendLine();
                }

                // Display report
                Console.WriteLine(report.ToString());
                TSM.Operations.Operation.DisplayPrompt("Reference model report generated. Check console output or log file.");

                // Optionally write to file
                string logPath = System.IO.Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                    string.Format("ReferenceModelReport_{0}.txt", DateTime.Now.ToString("yyyyMMdd_HHmmss"))
                );

                System.IO.File.WriteAllText(logPath, report.ToString());
                TSM.Operations.Operation.DisplayPrompt(string.Format("Report saved to: {0}", logPath));
            }
            catch (Exception ex) {
                TSM.Operations.Operation.DisplayPrompt(string.Format("Error: {0}", ex.Message));
                Console.WriteLine(string.Format("Error details: {0}", ex.ToString()));
            }
        }

        private static string GetReferenceModelName(TSD.ReferenceModel refDrawingObj) {
            try {

                // Try to get the reference model name
                string name = string.Empty;
                if (refDrawingObj.GetUserProperty("EXTERNAL_SOURCE_NAME", ref name)) {
                    return name;
                }

                // Alternative approach - get from model
                Model model = new Model();
                TSM.ModelObject refModelObj = model.SelectModelObject(refDrawingObj.ModelIdentifier);

                if (refModelObj is TSM.ReferenceModel) {
                    TSM.ReferenceModel rm = refModelObj as TSM.ReferenceModel;
                    string rmName = rm.Filename;
                    if (!string.IsNullOrEmpty(rmName)) {
                        return rmName;
                    }
                }
                return "Unknown Reference Model";
            }
            catch {
                return "Unknown Reference Model";
            }
        }
    }
}
