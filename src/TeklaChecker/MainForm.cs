using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Tekla.Structures;
using Tekla.Structures.Datatype;
using Tekla.Structures.Dialog;
using Tekla.Structures.Model;
using TeklaChecker.Helpers;
using TeklaChecker.Services;
using TeklaChecker.Tabs;

namespace TeklaChecker {

    public partial class MainForm : ApplicationFormBase {

        public MainForm() {
            InitializeForm();
            if (GetConnectionStatus()) {
                string messageFolder = null;
                TeklaStructuresSettings.GetAdvancedOption("XS_MESSAGES", ref messageFolder);
                messageFolder = Path.Combine(messageFolder, @"DotAppsStrings");
                Dialogs.SetSettings(string.Empty);
                Localization.Language = (string)Settings.GetValue("language");
                Localization.LoadFile(Path.Combine(messageFolder, Application.ProductName + ".xml"));
                Localization.Localize(this);
            }
            else {
                MessageBox.Show("Tekla Structures is NOT running...");
            }
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e) {
            tabPageSettings.Controls.Add(new SettingsTab { Dock = DockStyle.Fill });
            tabPageParts.Controls.Add(new PartsTab { Dock = DockStyle.Fill });
            tabPageClash.Controls.Add(new ClashTab { Dock = DockStyle.Fill });
            tabPageRebar.Controls.Add(new RebarTab { Dock = DockStyle.Fill });

            tabControl.SelectedTab = tabPageSettings;
        }


    }

}

