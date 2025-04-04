using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using Tekla.Structures.Dialog;
using Tekla.Structures.Model;

using TeklaChecker.Helpers;
using TeklaChecker.Services;
using TeklaChecker.Tabs;

namespace TeklaChecker {

    public partial class MainForm : ApplicationFormBase {

        public MainForm() {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e) {
            tabPageSettings.Controls.Add(new SettingsTab { Dock = DockStyle.Fill });
            tabPageParts.Controls.Add(new PartsTab { Dock = DockStyle.Fill });
            tabPageClash.Controls.Add(new ClashTab { Dock = DockStyle.Fill });
            tabPageRebar.Controls.Add(new RebarTab { Dock = DockStyle.Fill });
        }


    }

}

