using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using Tekla.Structures.Dialog;
using Tekla.Structures.Model;

namespace TeklaChecker
{
    public partial class CheckerForm : ApplicationFormBase
    {
        private readonly Checker ClashChecker = new Checker();

        public CheckerForm()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
        }

        private void ButtonRunCheck_Click(object sender, EventArgs e)
        {

            dataGridView1.DataSource = new List<ClashTableData>();
            dataGridView1.Update();

            if (ClashChecker.ClashCheck()) {
                FillDataGrid(ClashChecker.ClashData);
            }

            
        }

        private void FillDataGrid(List<ClashCheckData> ClashData) {

            List<ClashTableData> tableDataObjects = new List<ClashTableData>();

            dataGridView1.AutoGenerateColumns = false;
            DataGridViewTextBoxColumn IdColumn = new DataGridViewTextBoxColumn();
            IdColumn.DataPropertyName = "ID";
            IdColumn.HeaderText = "Clash index";

            DataGridViewTextBoxColumn Part1NameColumn = new DataGridViewTextBoxColumn();
            Part1NameColumn.DataPropertyName = "Part1Name";
            Part1NameColumn.HeaderText = "Part 1 name";

            DataGridViewTextBoxColumn Part2NameColumn = new DataGridViewTextBoxColumn();
            Part2NameColumn.DataPropertyName = "Part2Name";
            Part2NameColumn.HeaderText = "Part 2 name";

            DataGridViewTextBoxColumn ClashTypeColumn = new DataGridViewTextBoxColumn();
            ClashTypeColumn.DataPropertyName = "ClashType";
            ClashTypeColumn.HeaderText = "Clash type";

            dataGridView1.Columns.Add(IdColumn);
            dataGridView1.Columns.Add(Part1NameColumn);
            dataGridView1.Columns.Add(Part2NameColumn);
            dataGridView1.Columns.Add(ClashTypeColumn);

            for (int i = 0; i < ClashData.Count; i++) {
                tableDataObjects.Add(new ClashTableData(i, ClashData[i]));
            }
            dataGridView1.DataSource = tableDataObjects;
        }

        private void CheckerForm_Load(object sender, EventArgs e) {

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

