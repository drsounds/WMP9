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
    public partial class MediaView : UserControl
    {
        public Form1 host;
        
        public MediaView()
        {
           
            InitializeComponent();
        }
        public virtual void ApplyStylesheet(Stylesheet stylesheet)
        {
            this.BackColor = Parent.BackColor;
            this.ForeColor = Parent.ForeColor;
            foreach (Control c in this.Controls)
            {
                
                ApplyStylesheet(c, stylesheet);
                
                String type = c.GetType().Name;

                if (stylesheet.Selectors.ContainsKey(c.GetType().Name + ".background-color")) {
                    Color color = (Color)stylesheet.Selectors[c.GetType().FullName + ".background-color"];
                    c.BackColor = color;
                   
                }

                if (stylesheet.Selectors.ContainsKey(c.GetType().Name + ".color"))
                {
                    Color color = (Color)stylesheet.Selectors[c.GetType().FullName + ".color"];
                    c.ForeColor = color;

                }
            }
        }
        public virtual void ApplyStylesheet(Control control, Stylesheet stylesheet)
        {
            this.BackColor = Parent.BackColor;
            this.ForeColor = Parent.ForeColor;
            foreach (Control c in control.Controls)
            {
                ApplyStylesheet(c, stylesheet);
                
                String type = c.GetType().Name;
                try
                {
                    if (stylesheet.Selectors.ContainsKey(c.GetType().Name + ".background-color"))
                    {
                        Color color = (Color)stylesheet.Selectors[c.GetType().Name + ".background-color"];
                        c.BackColor = color;

                    }

                    if (stylesheet.Selectors.ContainsKey(c.GetType().Name + ".color"))
                    {
                        Color color = (Color)stylesheet.Selectors[c.GetType().Name + ".color"];
                        c.ForeColor = color;

                    }
                }
                catch (Exception e)
                {

                }
            }
        }
        private void MediaView_Load(object sender, EventArgs e)
        {

        }
    }
}
