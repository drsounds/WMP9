using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Windows_Media_Player_9
{
    public partial class ColorChooserView : MediaView
    {
        public ColorChooserView()
        {
            InitializeComponent();
        }


        public void Apply()
        {
            this.host.Stylesheet.Hue = trackBar1.Value;
            this.host.Stylesheet.Saturation = trackBar2.Value;
            this.host.Stylesheet.Lumosity = trackBar3.Value;
            this.host.Stylesheet.Light = checkBox1.Checked;
            this.host.Stylesheet.Generate();
            this.host.ApplyStylesheet(this.host.Stylesheet);


        }

        private void ColorChooserView_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Apply();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.host.Stylesheet.Light = checkBox1.Checked;
        }
    }
}
