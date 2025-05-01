using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tekla.Structures.Model;
using TeklaChecker.Helpers;
using TeklaChecker.Services;

namespace TeklaChecker.Tabs {
    public partial class ClashTab : UserControl {

        private readonly ClashChecker ClashChecker = new ClashChecker();
        public double settingOverlap;

        public ClashTab() {
            InitializeComponent();
            ClashTab_Load();
        }

        private void ClashTab_Load() {
            string relativePath = Path.Combine("Settings", "default.ccr");
            string fullPath = Path.Combine(AppContext.BaseDirectory, relativePath);
            if (File.Exists(fullPath))
                textBoxFilePathClashSettings.Text = fullPath;
            else
                textBoxFilePathClashSettings.Text = "Default file not found!";
        }

        private void ButtonRunCheck_Click(object sender, EventArgs e) {

            var clashRules = ClashChecker.LoadClashConfig(textBoxFilePathClashSettings.Text);

            dataGridView1.DataSource = new List<ClashTableData>();
            dataGridView1.Update();

            if (ClashChecker.ClashCheck(clashRules)) {
                FillDataGrid(ClashChecker.ClashData);
                dataGridView1.Enabled = true;
            }
        }

        private void FillDataGrid(List<ClashCheckData> ClashData) {

            DataGridColumnId.DataPropertyName = "ID";
            DataGridColumnPart1Name.DataPropertyName = "Part1Name";
            DataGridColumnPart2Name.DataPropertyName = "Part2Name";
            DataGridColumnClashType.DataPropertyName = "ClashType";
            DataGridColumnOverlap.DataPropertyName = "Overlap";

            List<ClashTableData> tableDataObjects = new List<ClashTableData>();
            for (int i = 0; i < ClashData.Count; i++) {
                tableDataObjects.Add(new ClashTableData(i, ClashData[i]));
            }
            dataGridView1.DataSource = tableDataObjects;
        }

        private void DataGridCellDoubleClick(object sender, DataGridViewCellMouseEventArgs e) {
            ModelObject mo1 = ClashChecker.ClashData[e.RowIndex].Object1;
            ModelObject mo2 = ClashChecker.ClashData[e.RowIndex].Object2;
            var parts = new Part[] { mo1 as Part, mo2 as Part };

            SelectionHelper selector = new SelectionHelper();
            selector.SelectParts(parts);

            ViewHelper viewer = new ViewHelper();
            viewer.ZoomToParts(parts);

            viewer.RemoveDrawnCrashBoundingBox();
            viewer.DrawCrashBoundingBox(mo1.Identifier.ID, mo2.Identifier.ID);
        }

        private void label2_Click(object sender, EventArgs e) {

        }

        private void buttonBrowseClashSettings_Click(object sender, EventArgs e) {
            // Set initial directory to the folder from the textbox, if valid
            using (OpenFileDialog openFileDialog = new OpenFileDialog()) {
                
                string currentPath = textBoxFilePathClashSettings.Text;
                if (!string.IsNullOrWhiteSpace(currentPath) && File.Exists(currentPath))
                    openFileDialog.InitialDirectory = Path.GetDirectoryName(currentPath);
                else if (!string.IsNullOrWhiteSpace(currentPath) && Directory.Exists(currentPath))
                    openFileDialog.InitialDirectory = currentPath;
                else
                    openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                openFileDialog.Filter = "Clash check rules (*.ccr)|*.ccr";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK) {
                    // Get the path of specified file
                    string filePath = openFileDialog.FileName;
                    textBoxFilePathClashSettings.Text = filePath;
                }
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e) {

        }
    }

    public class ClashTableData {


        public int ID { get; private set; }
        public string Part1Name { get; private set; }
        public string Part2Name { get; private set; }
        public string ClashType { get; private set; }
        public double Overlap { get; private set; }


        readonly String[] ClashTypeStrings = new String[] {
            "Invalid",
            "Is inside",
            "Duplicate",
            "Clash",
            "Min distance",
            "Failed solid",
            "Cut through",
            "Complex",
            "FAILED"
        };

        public ClashTableData(int id, ClashCheckData cData) {
            ID = id;
            Part part1 = cData.Object1 as Part;
            Part part2 = cData.Object2 as Part;
            string part1Name = "";
            string part2Name = "";
            part1.GetReportProperty("NAME", ref part1Name);
            part2.GetReportProperty("NAME", ref part2Name);
            Part1Name = part1Name;
            Part2Name = part2Name;
            ClashType = ClashTypeStrings[(int)cData.Type];
            Overlap = cData.Overlap * 1000;
        }
    }
}
