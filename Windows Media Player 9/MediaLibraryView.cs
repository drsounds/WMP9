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
    public partial class MediaLibraryView : MediaView
    {
        public String currentUri;
        public Stack<String> History = new Stack<string>();
        public Stack<String> Future = new Stack<string>();
            MediaDatabase database = new MediaDatabase();
        public void RenderArtists() 
        {
            var artistsNode = this.treeView1.Nodes[0].Nodes[0];
            artistsNode.Nodes.Clear();
            List<artist> artists = database.GetAllArtists();
            foreach (artist artist in artists)
            {
                var item = new TreeNode(artist.artist, -1, -1);
                artistsNode.Nodes.Add(item);
            }
        }
        public void Navigate(string uri)
        {
            if (uri.StartsWith("wmp:"))
            {
                String[] tokens = uri.Split(':');
                var type = tokens[1];
                var argument = tokens[2];
                if (type == "artist") {
                   
                }
            }
        }
        public MediaLibraryView()
        {
            InitializeComponent();
        }

        private void MediaLibraryView_Load(object sender, EventArgs e)
        {

        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            ImportMusicForm imf = new ImportMusicForm();
            imf.Show();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
    }
}
