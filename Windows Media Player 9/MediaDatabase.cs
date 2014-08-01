using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.IO;
namespace Windows_Media_Player_9
{
    public class song
    {
        public int id { get; set; }
        public string title { get; set; }
        public string version { get; set; }
        public string artist { get; set; }
        public string album { get; set; }
        public string uri { get; set; }
    }
    public class artist
    {
        public string artist;
    }
    public delegate void SongImportEventHandler(object sender, SongImportEventArgs e);
    public class MediaDatabase
    {
        public List<artist> GetAllArtists()
        {
            using (var conn = Connect())
            {
                List<artist> artists = conn.Query<artist>("SELECT DISTINCT(artist) FROM song");
                return artists;
            }
          
        }
        public List<song> GetTracksByArtist(string artist)
        {
            using (var conn = Connect())
            {
                List<song> songs = conn.Query<song>("SELECT * FROM song WHERE artist = ?", artist);
                return songs;
            }
          
        }
        SQLiteConnection conn;
        public event SongImportEventHandler SongImported;
        public MediaDatabase()
        {
              

        }
        public SQLiteConnection Connect()
        {

            SQLiteConnection myConn = new SQLiteConnection("DataSource=./database");
            this.conn = myConn;
            return this.conn;
        }
        public void Disconnect()
        {
            conn.Dispose();
        }
        public void Scan(string startDir)
        {

          
            Connect();
            
            ScanMediaFiles(startDir);
            Disconnect();
        }
        /// <summary>
        /// Scan for media files
        /// </summary>
        /// <param name="startDir"></param>
        public async void ScanMediaFiles(string startDir)
        {
            using (var connection = Connect())
            {
                String[] files = Directory.GetFiles(startDir);
                foreach (String file in files)
                {
                    if (file.EndsWith(".mp3"))
                    {
                        try
                        {
                            id3.MP3 Dw = new id3.MP3(file, file);
                            id3.FileCommands.readMP3Tag(ref Dw);

                            song song = new song();
                            song.title = Dw.id3Title;
                            song.artist = Dw.id3Artist;
                            song.album = Dw.id3Album;
                            song.uri = "mp3:" + file;
                            // return a new song
                            connection.Insert(song);
                            this.SongImported.Invoke(this, new SongImportEventArgs() { Song = song });
                        }
                        catch (Exception e)
                        {

                        }
                    }
                }
                String[] directories = Directory.GetDirectories(startDir);
                foreach (String directory in directories)
                {
                    ScanMediaFiles(directory);
                }
            }
        }
    }
}
