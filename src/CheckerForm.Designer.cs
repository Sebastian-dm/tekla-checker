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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ButtonRunCheck
            // 
            this.structuresExtender.SetAttributeName(this.ButtonRunCheck, null);
            this.structuresExtender.SetAttributeTypeName(this.ButtonRunCheck, null);
            this.structuresExtender.SetBindPropertyName(this.ButtonRunCheck, null);
            this.ButtonRunCheck.Location = new System.Drawing.Point(12, 270);
            this.ButtonRunCheck.Name = "ButtonRunCheck";
            this.ButtonRunCheck.Size = new System.Drawing.Size(75, 23);
            this.ButtonRunCheck.TabIndex = 1;
            this.ButtonRunCheck.Text = "Run Check";
            this.ButtonRunCheck.UseVisualStyleBackColor = true;
            this.ButtonRunCheck.Click += new System.EventHandler(this.ButtonRunCheck_Click);
            // 
            // dataGridView1
            // 
            this.structuresExtender.SetAttributeName(this.dataGridView1, null);
            this.structuresExtender.SetAttributeTypeName(this.dataGridView1, null);
            this.structuresExtender.SetBindPropertyName(this.dataGridView1, null);
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(499, 252);
            this.dataGridView1.TabIndex = 2;
            // 
            // CheckerForm
            // 
            this.structuresExtender.SetAttributeName(this, null);
            this.structuresExtender.SetAttributeTypeName(this, null);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.structuresExtender.SetBindPropertyName(this, null);
            this.ClientSize = new System.Drawing.Size(523, 305);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.ButtonRunCheck);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CheckerForm";
            this.Text = "Tekla Clash Checker";
            this.Load += new System.EventHandler(this.CheckerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button ButtonRunCheck;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

