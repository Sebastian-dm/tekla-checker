namespace TeklaChecker.Tabs {
    partial class ClashTab {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxFilePathClashSettings;
        private System.Windows.Forms.Button buttonBrowseClashSettings;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button ButtonRunCheck;
        private System.Windows.Forms.DataGridView dataGridView1;
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
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxFilePathClashSettings = new System.Windows.Forms.TextBox();
            this.buttonBrowseClashSettings = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblNoData = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonRunCheck
            // 
            this.ButtonRunCheck.AutoSize = true;
            this.ButtonRunCheck.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ButtonRunCheck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonRunCheck.Location = new System.Drawing.Point(655, 3);
            this.ButtonRunCheck.Name = "ButtonRunCheck";
            this.ButtonRunCheck.Size = new System.Drawing.Size(71, 23);
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
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DataGridColumnId,
            this.DataGridColumnPart1Name,
            this.DataGridColumnPart2Name,
            this.DataGridColumnClashType,
            this.DataGridColumnOverlap});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Enabled = false;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(729, 538);
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
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Clash settings:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // textBoxFilePathClashSettings
            // 
            this.textBoxFilePathClashSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFilePathClashSettings.Location = new System.Drawing.Point(84, 4);
            this.textBoxFilePathClashSettings.Name = "textBoxFilePathClashSettings";
            this.textBoxFilePathClashSettings.Size = new System.Drawing.Size(533, 20);
            this.textBoxFilePathClashSettings.TabIndex = 7;
            // 
            // buttonBrowseClashSettings
            // 
            this.buttonBrowseClashSettings.AutoSize = true;
            this.buttonBrowseClashSettings.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonBrowseClashSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonBrowseClashSettings.Location = new System.Drawing.Point(623, 3);
            this.buttonBrowseClashSettings.Name = "buttonBrowseClashSettings";
            this.buttonBrowseClashSettings.Size = new System.Drawing.Size(26, 23);
            this.buttonBrowseClashSettings.TabIndex = 8;
            this.buttonBrowseClashSettings.Text = "...";
            this.buttonBrowseClashSettings.UseVisualStyleBackColor = true;
            this.buttonBrowseClashSettings.Click += new System.EventHandler(this.buttonBrowseClashSettings_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.textBoxFilePathClashSettings, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonBrowseClashSettings, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.ButtonRunCheck, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 550);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(20);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(729, 29);
            this.tableLayoutPanel1.TabIndex = 9;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // lblNoData
            // 
            this.lblNoData.AutoSize = true;
            this.lblNoData.BackColor = System.Drawing.Color.Transparent;
            this.lblNoData.Enabled = false;
            this.lblNoData.Location = new System.Drawing.Point(15, 37);
            this.lblNoData.Name = "lblNoData";
            this.lblNoData.Size = new System.Drawing.Size(156, 13);
            this.lblNoData.TabIndex = 10;
            this.lblNoData.Text = "The check ran with no clashes.";
            this.lblNoData.Visible = false;
            // 
            // ClashTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblNoData);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ClashTab";
            this.Padding = new System.Windows.Forms.Padding(12);
            this.Size = new System.Drawing.Size(753, 591);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNoData;
    }
}
