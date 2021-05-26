using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PVS.MediaPlayer;
using System.Net.Sockets;

namespace AVPlayer
{
    public partial class Playlist : Form
    {
        public List<string> nameList;

        public Playlist()
        {
            InitializeComponent();

            listOfPlay.Columns.Add("Cover",55);
            listOfPlay.Columns.Add("Name");
            listOfPlay.Columns.Add("Author");
            listOfPlay.Columns.Add("Length");
            nameList = new List<string>();
            listOfPlay.SmallImageList = covers;
            
        }

        private bool mouseDown;
        private Point lastLocation;

        private void Playlist_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void Playlist_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void Playlist_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            openFileDialog.Filter = "Video files |*.mp4;*.avi;*.mkv;*.wmv;*.flv;*.mov;|Audio files|*.mp3;*.ogg;*.m4a;*.flac;*.wav;*.vma;*.aac;";

            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = false;
            int index = 1;

            Player pl = new Player();
 
            
            string[] musicEx = new string[] { ".mp3", ".ogg", ".m4a", ".flac", ".wav", ".vma", ".aac" };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pl.Play(openFileDialog.FileName, null);
                Metadata M = pl.Media.GetMetadata();

                if (musicEx.Contains((Path.GetExtension(openFileDialog.FileName)), StringComparer.OrdinalIgnoreCase))
                {
                    index = 0;
                }
                listOfPlay.Items.Add(new ListViewItem(new string[] { "", openFileDialog.SafeFileName, M.Artist,(M.Duration.ToString()) }, index));
                
                nameList.Add(openFileDialog.FileName);

            }
            pl.Dispose();
            pl = null;
        }

        private void delLastButton_Click(object sender, EventArgs e)
        {
            nameList.RemoveAt(nameList.Count - 1);
            listOfPlay.Items.RemoveAt(nameList.Count);
        }

        private void delAllButton_Click(object sender, EventArgs e)
        {
            nameList.Clear();
            listOfPlay.Items.Clear();
        }

        private void miniButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
