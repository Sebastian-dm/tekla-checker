using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using Tekla.Structures.Dialog;
using Tekla.Structures.Model;

namespace TeklaChecker {

    public partial class CheckerForm : ApplicationFormBase {

        private readonly Checker ClashChecker = new Checker();

        public CheckerForm() {
            InitializeComponent();
            dataGridView1.Enabled = false;
        }

        private void ButtonRunCheck_Click(object sender, EventArgs e) {

            dataGridView1.DataSource = new List<ClashTableData>();
            dataGridView1.Update();

            if (ClashChecker.ClashCheck()) {
                FillDataGrid(ClashChecker.ClashData);
                dataGridView1.Enabled = true;
            }

        }

        private void FillDataGrid(List<ClashCheckData> ClashData) {

            DataGridColumnId.DataPropertyName = "ID";
            DataGridColumnPart1Name.DataPropertyName = "Part1Name";
            DataGridColumnPart2Name.DataPropertyName = "Part2Name";
            DataGridColumnClashType.DataPropertyName = "ClashType";

            List<ClashTableData> tableDataObjects = new List<ClashTableData>();
            for (int i = 0; i < ClashData.Count; i++) {
                tableDataObjects.Add(new ClashTableData(i, ClashData[i]));
            }
            dataGridView1.DataSource = tableDataObjects;
        }


        private void DataGridCellDoubleClick(object sender, DataGridViewCellMouseEventArgs e) {

            var parts = new Part[] {
                ClashChecker.ClashData[e.RowIndex].Object1 as Part,
                ClashChecker.ClashData[e.RowIndex].Object2 as Part
            };

            SelectionHelper selector = new SelectionHelper();
            selector.SelectParts(parts);

            ViewHelper viewer = new ViewHelper();
            viewer.ZoomToParts(parts);
        }
    }

    public class ClashTableData {


        public int ID { get; private set; }
        public string Part1Name { get; private set; }
        public string Part2Name { get; private set; }
        public string ClashType { get; private set; }


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
        }
    }

}

