namespace TeklaChecker
{
    partial class CheckerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckerForm));
            this.ButtonRunCheck = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.DataGridColumnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGridColumnPart1Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGridColumnPart2Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGridColumnClashType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ButtonRunCheck
            // 
            this.structuresExtender.SetAttributeName(this.ButtonRunCheck, null);
            this.structuresExtender.SetAttributeTypeName(this.ButtonRunCheck, null);
            this.structuresExtender.SetBindPropertyName(this.ButtonRunCheck, null);
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
            this.structuresExtender.SetAttributeName(this.dataGridView1, null);
            this.structuresExtender.SetAttributeTypeName(this.dataGridView1, null);
            this.structuresExtender.SetBindPropertyName(this.dataGridView1, null);
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DataGridColumnId,
            this.DataGridColumnPart1Name,
            this.DataGridColumnPart2Name,
            this.DataGridColumnClashType});
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(354, 381);
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
            this.DataGridColumnClashType.HeaderText = "Clash type";
            this.DataGridColumnClashType.Name = "DataGridColumnClashType";
            this.DataGridColumnClashType.ReadOnly = true;
            // 
            // CheckerForm
            // 
            this.structuresExtender.SetAttributeName(this, null);
            this.structuresExtender.SetAttributeTypeName(this, null);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.structuresExtender.SetBindPropertyName(this, null);
            this.ClientSize = new System.Drawing.Size(377, 434);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.ButtonRunCheck);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CheckerForm";
            this.Text = "Tekla Clash Checker";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button ButtonRunCheck;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGridColumnId;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGridColumnPart1Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGridColumnPart2Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGridColumnClashType;
    }
}

