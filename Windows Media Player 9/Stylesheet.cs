using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Windows_Media_Player_9
{
    public class Stylesheet
    {
        /// <summary>
        /// Provided for read write in order to get the color chooser to work 
        /// </summary>
        public int Hue { get; set; }
        public int Saturation { get; set; }
        public int Lumosity { get; set; }
        public bool Light { get; set; }
        [DllImport("shlwapi.dll")]
        public static extern int ColorHLSToRGB(int H, int L, int S);
        public Stylesheet()
        {
            selectors = new Dictionary<string, object>();
        }

        /// <summary>
        /// Generate stylesheet from slider position
        /// </summary>
        /// <returns></returns>
        public void Generate()
        {
            // Generate generic back color
            int hue = this.Hue, saturation = this.Saturation, lumosity = Lumosity;
            Color backgroundColor = ColorTranslator.FromWin32(Stylesheet.ColorHLSToRGB(hue, lumosity, saturation));
            this.Set("MediaView.background-color", ColorTranslator.ToHtml(backgroundColor));
            Color foreColor = ColorTranslator.FromWin32(Stylesheet.ColorHLSToRGB(hue, lumosity + (int)((lumosity / 240) * 0.5f), saturation));
            this.Set("MediaView.color", ColorTranslator.ToHtml(foreColor));

            // Generate listview color
            if (this.Light)
            {
                Color bgColor = ColorTranslator.FromWin32(Stylesheet.ColorHLSToRGB(hue, lumosity, (int)(saturation * 0.2f)));
                Color fgColor = ColorTranslator.FromWin32(Stylesheet.ColorHLSToRGB(hue, lumosity, saturation));
                bgColor = ControlPaint.Light(bgColor, 1.8f);
                this.Set("ListView.background-color", ColorTranslator.ToHtml(bgColor));
                this.Set("ListView.color", ColorTranslator.ToHtml(ControlPaint.Dark(fgColor, .5f)));
                this.Set("ListView::alternate.color", ColorTranslator.ToHtml(ControlPaint.Dark(fgColor, 0.5f)));
                this.Set("TreeView.background-color", ColorTranslator.ToHtml(bgColor));
                this.Set("TreeView.color", ColorTranslator.ToHtml(ControlPaint.Dark(fgColor, 0.5f)));
            }
            else
            {
                Color bgColor = ColorTranslator.FromWin32(Stylesheet.ColorHLSToRGB(hue, lumosity, saturation));
                Color fgColor = Color.White;
                Color alternateColor = ControlPaint.Dark(bgColor, 1.02f);
                bgColor = ControlPaint.Dark(bgColor, 0.4f);
                this.Set("ListView.background-color", ColorTranslator.ToHtml(bgColor));
                this.Set("ListView.color", ColorTranslator.ToHtml(fgColor));
                this.Set("TreeView.background-color", ColorTranslator.ToHtml(bgColor));
                this.Set("TreeView.color", ColorTranslator.ToHtml(fgColor));
            }

            // MediaToolbar
            this.Set("MediaToolbar.background-color", ColorTranslator.ToHtml(ColorTranslator.FromWin32(Stylesheet.ColorHLSToRGB(hue, saturation - (int)((saturation / 240) *0.1f), lumosity))));
            this.Set("MediaToolbar.color", ColorTranslator.ToHtml(foreColor));

        }
            
        public Stylesheet(String fileName)
        {
            selectors = new Dictionary<string, object>();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(fileName);
            var meta = xmlDoc.GetElementsByTagName("meta");
            Hue = int.Parse(((XmlElement)meta[0]).GetAttribute("hue"));
            Saturation = int.Parse(((XmlElement)meta[0]).GetAttribute("saturation"));
            Light = bool.Parse(((XmlElement)meta[0]).GetAttribute("light"));
            var elements = xmlDoc.GetElementsByTagName("selector");
            foreach (XmlNode sel in elements)
            {
                if (sel.GetType() == typeof(XmlElement))
                {
                    XmlElement selector = (XmlElement)sel;
                    this.Set(selector.GetAttribute("selector"), selector.GetAttribute("value"));
                }
            }

        }
        public void Save(String fileName)
        {
            XmlDocument xmlDoc = new XmlDocument();
            var elm = xmlDoc.CreateElement("theme");
            var meta = xmlDoc.CreateElement("meta");
            xmlDoc.AppendChild(elm);
            meta.SetAttribute("light", Light.ToString());
            meta.SetAttribute("hue", Hue.ToString());
            meta.SetAttribute("lumosity", Lumosity.ToString());
            elm.AppendChild(meta);
            foreach (KeyValuePair<String, Object> selector in selectors)
            {
                Object value = selector.Value;
                String strValue = "";
                if (value.GetType() == typeof(Color))
                {
                    strValue = ColorTranslator.ToHtml((Color)value);

                }
                var elmSelector = xmlDoc.CreateElement("selector");
                elmSelector.SetAttribute("selector", selector.Key);
                elmSelector.SetAttribute("value", strValue);
                xmlDoc.DocumentElement.AppendChild(elmSelector);
            }
            xmlDoc.Save(fileName);
        }
        public Color Parse(String strColor)
        {
            var matches = Regex.Matches(strColor, @"([0-9]+\.[0-9]+)");

            if (matches.Count == 4)
            {
                Color color = Color.FromArgb(int.Parse(matches[4].Value), int.Parse(matches[0].Value), int.Parse(matches[1].Value), int.Parse(matches[2].Value));
                return color;
            }
            return Color.FromArgb(0, 0, 0, 0);
        }
        private Dictionary<String, Object> selectors;
        public Dictionary<String, Object> Selectors
        {
            get
            {
                return selectors;
            }
        }
        public void Set(String selector, string value)
        {
            Object val = null;
            /*if (value.StartsWith("#"))
            {
                // Assume color
                Color color = ColorTranslator.FromHtml(value);
                val = color;
            }
            if (value.StartsWith("rgba("))
            {
                Color color = Parse(value);
                val = color;
            }*/
            Color color = ColorTranslator.FromHtml(value);
            val = color;
            selectors[selector] = val;
        }
    }
}
