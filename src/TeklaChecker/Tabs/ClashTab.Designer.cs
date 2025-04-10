﻿namespace TeklaChecker.Tabs {
    partial class ClashTab {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Button ButtonRunCheck;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownOverlap;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGridColumnId;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGridColumnPart1Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGridColumnPart2Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGridColumnClashType;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGridColumnOverlap;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent() {
            this.ButtonRunCheck = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.DataGridColumnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGridColumnPart1Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGridColumnPart2Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGridColumnClashType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGridColumnOverlap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownOverlap = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOverlap)).BeginInit();
            this.SuspendLayout();
            // 
            // ButtonRunCheck
            // 
            this.ButtonRunCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ButtonRunCheck.Location = new System.Drawing.Point(12, 399);
            this.ButtonRunCheck.Name = "ButtonRunCheck";
            this.ButtonRunCheck.Size = new System.Drawing.Size(75, 23);
            this.ButtonRunCheck.TabIndex = 1;
            this.ButtonRunCheck.Text = "Run Check";
            this.ButtonRunCheck.UseVisualStyleBackColor = true;
            this.ButtonRunCheck.Click += new System.EventHandler(this.ButtonRunCheck_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DataGridColumnId,
            this.DataGridColumnPart1Name,
            this.DataGridColumnPart2Name,
            this.DataGridColumnClashType,
            this.DataGridColumnOverlap});
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(436, 381);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridCellDoubleClick);
            // 
            // DataGridColumnId
            // 
            this.DataGridColumnId.FillWeight = 50F;
            this.DataGridColumnId.HeaderText = "#";
            this.DataGridColumnId.Name = "DataGridColumnId";
            this.DataGridColumnId.ReadOnly = true;
            this.DataGridColumnId.Width = 50;
            // 
            // DataGridColumnPart1Name
            // 
            this.DataGridColumnPart1Name.HeaderText = "Part 1 Name";
            this.DataGridColumnPart1Name.Name = "DataGridColumnPart1Name";
            this.DataGridColumnPart1Name.ReadOnly = true;
            // 
            // DataGridColumnPart2Name
            // 
            this.DataGridColumnPart2Name.HeaderText = "Part 2 Name";
            this.DataGridColumnPart2Name.Name = "DataGridColumnPart2Name";
            this.DataGridColumnPart2Name.ReadOnly = true;
            // 
            // DataGridColumnClashType
            // 
            this.DataGridColumnClashType.HeaderText = "Clash Type";
            this.DataGridColumnClashType.Name = "DataGridColumnClashType";
            this.DataGridColumnClashType.ReadOnly = true;
            // 
            // DataGridColumnOverlap
            // 
            this.DataGridColumnOverlap.HeaderText = "Overlap";
            this.DataGridColumnOverlap.Name = "DataGridColumnOverlap";
            this.DataGridColumnOverlap.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(250, 404);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Min. overlap:";
            // 
            // numericUpDownOverlap
            // 
            this.numericUpDownOverlap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numericUpDownOverlap.DecimalPlaces = 2;
            this.numericUpDownOverlap.Location = new System.Drawing.Point(324, 402);
            this.numericUpDownOverlap.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownOverlap.Name = "numericUpDownOverlap";
            this.numericUpDownOverlap.Size = new System.Drawing.Size(41, 20);
            this.numericUpDownOverlap.TabIndex = 5;
            this.numericUpDownOverlap.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // ClashTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.numericUpDownOverlap);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.ButtonRunCheck);
            this.Name = "ClashTab";
            this.Size = new System.Drawing.Size(460, 434);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOverlap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
