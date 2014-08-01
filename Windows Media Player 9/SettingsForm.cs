using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Windows_Media_Player_9
{
    public partial class SettingsForm : Form
    {
        public Form1 Host;
        public SettingsForm()
        {
            InitializeComponent();
        }

        public SettingsForm(Form1 host)
        {
            InitializeComponent();
            this.Host = host;
        }
        private void SettingsForm_Load(object sender, EventArgs e)
        {
            this.colorChooserView1.host = this.Host;
        }
    }
}
