namespace TeklaChecker {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageSettings;
        private System.Windows.Forms.TabPage tabPageParts;
        private System.Windows.Forms.TabPage tabPageClash;
        private System.Windows.Forms.TabPage tabPageRebar;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent() {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageSettings = new System.Windows.Forms.TabPage();
            this.tabPageParts = new System.Windows.Forms.TabPage();
            this.tabPageClash = new System.Windows.Forms.TabPage();
            this.tabPageRebar = new System.Windows.Forms.TabPage();
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageSettings);
            this.tabControl.Controls.Add(this.tabPageParts);
            this.tabControl.Controls.Add(this.tabPageClash);
            this.tabControl.Controls.Add(this.tabPageRebar);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(800, 450);
            this.tabControl.TabIndex = 0;
            // 
            // tabPageSettings
            // 
            this.tabPageSettings.Location = new System.Drawing.Point(4, 22);
            this.tabPageSettings.Name = "tabPageSettings";
            this.tabPageSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSettings.Size = new System.Drawing.Size(792, 424);
            this.tabPageSettings.TabIndex = 0;
            this.tabPageSettings.Text = "Settings";
            this.tabPageSettings.UseVisualStyleBackColor = true;
            // 
            // tabPageParts
            // 
            this.tabPageParts.Location = new System.Drawing.Point(4, 22);
            this.tabPageParts.Name = "tabPageParts";
            this.tabPageParts.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageParts.Size = new System.Drawing.Size(792, 424);
            this.tabPageParts.TabIndex = 1;
            this.tabPageParts.Text = "Parts";
            this.tabPageParts.UseVisualStyleBackColor = true;
            // 
            // tabPageClash
            // 
            this.tabPageClash.Location = new System.Drawing.Point(4, 22);
            this.tabPageClash.Name = "tabPageClash";
            this.tabPageClash.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageClash.Size = new System.Drawing.Size(792, 424);
            this.tabPageClash.TabIndex = 2;
            this.tabPageClash.Text = "Clash";
            this.tabPageClash.UseVisualStyleBackColor = true;
            // 
            // tabPageRebar
            // 
            this.tabPageRebar.Location = new System.Drawing.Point(4, 22);
            this.tabPageRebar.Name = "tabPageRebar";
            this.tabPageRebar.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRebar.Size = new System.Drawing.Size(792, 424);
            this.tabPageRebar.TabIndex = 3;
            this.tabPageRebar.Text = "Rebar";
            this.tabPageRebar.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl);
            this.Name = "MainForm";
            this.Text = "Tekla Checker";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion
    }
}
