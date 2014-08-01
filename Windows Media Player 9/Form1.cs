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
    public partial class Form1 : Form
    {
        private Stylesheet stylesheet;
        public Stylesheet Stylesheet
        {
            get
            {
                return stylesheet;
            }
        }
        public Form1()
        {
            InitializeComponent();
        }
        public void ApplyStylesheet(Stylesheet stylesheet)
        {
            foreach (Control c in this.toolStripContainer1.ContentPanel.Controls)
            {
                if (c is MediaView)
                {
                    ((MediaView)c).ApplyStylesheet(stylesheet);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            stylesheet = new Stylesheet("theme.xml");
            ApplyStylesheet(stylesheet);

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm(this);
            settingsForm.Show();
        }
    }
}
