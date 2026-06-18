using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using TeklaChecker.Services;

namespace TeklaChecker.Tabs {
    public partial class SettingsTab : UserControl {
        public SettingsTab() {
            InitializeComponent();
        }

        private void buttonRunRefCheck_Click(object sender, EventArgs e) {
            ReferenceChecker refChecker = new ReferenceChecker();

        }
    }
}
