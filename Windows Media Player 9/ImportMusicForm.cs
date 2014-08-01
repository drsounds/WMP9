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
    public partial class ImportMusicForm : Form
    {
        
        public ImportMusicForm()
        {
            InitializeComponent();
            md.SongImported += md_SongImported;
            bw.DoWork += bw_DoWork;
            bw.RunWorkerCompleted += bw_RunWorkerCompleted;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = fbd.SelectedPath;
            }
        }
        public event SongImportEventHandler SongImported;

        BackgroundWorker bw = new BackgroundWorker();
        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            bw.RunWorkerAsync(textBox1.Text);
        }

        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            button2.Enabled = true;
        }
        MediaDatabase md = new MediaDatabase();

        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            md.Scan((string)e.Argument);
        }

        void md_SongImported(object sender, SongImportEventArgs e)
        {
            bw.ReportProgress(1);
        }
    }
    public class SongImportEventArgs
    {
        public song Song { get; set; }
    }
  
}
