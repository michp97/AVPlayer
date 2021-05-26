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

namespace AVPlayer
{
    public partial class playerWindow : Form
    {
        Player myPlayer;
        bool fullScreen = false;
        List<string> ex = new List<string> { ".mp4", ".avi", ".wmv", ".flv", ".mov", ".mp3", ".ogg", ".wma", ".flac", ".aac", ".mkv", ".m4a", ".wav" };
        AVPlayer.Playlist playL = new AVPlayer.Playlist();
        List<string> files;
        int filesToPlay;
        bool isPlaylistOpen = false;

        public playerWindow()
        {
            InitializeComponent();

            files = new List<string>();
            filesToPlay = -1;

            this.ControlBox = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Text = "";

            myPlayer = new Player();
            myPlayer.Display.Window = viewPanel;

            myPlayer.Events.MediaSubtitleChanged += MyPlayer_MediaSubtitleChanged;
            myPlayer.Subtitles.DirectoryDepth = 1;
            myPlayer.Sliders.Position.TrackBar = progressBar;
            myPlayer.Sliders.AudioVolume = volumeBar;
            myPlayer.Events.MediaPositionChanged += myPlayer_MediaPositionChanged;
            myPlayer.Events.MediaEnded += MyPlayer_MediaEnded;

        }

        private bool mouseDown;
        private Point lastLocation;

        private void ViewPanel_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void ViewPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void ViewPanel_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void myPlayer_MediaPositionChanged(object sender, PositionEventArgs e)
        {
            TimeSpan fromStart = TimeSpan.FromTicks(e.FromStart);
            label1.Text = fromStart.ToString(@"hh\:mm\:ss");
        }

        private void MyPlayer_MediaSubtitleChanged(object sender, SubtitleEventArgs e)
        {
            subtitlesLabel.Text = e.Subtitle;
        }

        void MyPlayer_MediaEnded(object sender, EndedEventArgs e)
        {
            viewPanel.BackgroundImage = null;
            playButton.ImageIndex = 0;
            titleLabel.Text = "No file :(";

            if (e.StopReason == StopReason.Finished) PlayNext();
        }

        private void PlayNext()
        {
            if (++filesToPlay >= files.Count)
                filesToPlay = 0;
            if(files.Count!=0)
                loadFile(files[filesToPlay]);
        }

        private void OpenButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            openFileDialog.Filter = "Video files |*.mp4;*.avi;*.mkv;*.wmv;*.flv;*.mov;|Audio files|*.mp3;*.ogg;*.m4a;*.flac;*.wav;*.vma;*.aac;";

            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                loadFile(openFileDialog.FileName);
            }
        }

        private void loadFile(string file)
        {
            viewPanel.BackgroundImage = null;
            myPlayer.Play(file, viewPanel);
            myPlayer.SleepDisabled = true;
            myPlayer.CursorHide.Add(this);
            Metadata meta = myPlayer.Media.GetMetadata();
            if (myPlayer.Media.GetVideoTracks() == null)
            {
                titleLabel.Text = meta.Artist + " - " + meta.Title;
                viewPanel.BackgroundImage = meta.Image;
                viewPanel.BackgroundImageLayout = ImageLayout.Zoom;
            }
            else
            {
                titleLabel.Text = meta.Title;
            }
            TimeSpan Stop = myPlayer.Media.Length;
            label2.Text = Stop.ToString(@"hh\:mm\:ss");
            if (myPlayer.LastError) MessageBox.Show(myPlayer.LastErrorString);
            playButton.ImageIndex = 2;
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            if (myPlayer.Paused == false)
            {
                myPlayer.Pause();
                playButton.ImageIndex = 1;
            }
            else { 
                myPlayer.Paused = false;
                playButton.ImageIndex = 3;
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            myPlayer.Stop();
            myPlayer.SleepDisabled=false;
            titleLabel.Text = "No file :(";
            playButton.ImageIndex = 0;
            viewPanel.BackgroundImage = null;
            nextButton.Visible = false;
            filesToPlay = -1;
            files = null;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            myPlayer.Dispose();
            myPlayer = null;
            Close();
        }

        private void fullScr()
        {
            if (fullScreen == false)
            {
                this.WindowState = FormWindowState.Maximized;
                this.FormBorderStyle = FormBorderStyle.None;
                fullScreen = true;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = FormBorderStyle.Sizable;
                fullScreen = false;

            }

        }
        private void fullscrButton_Click(object sender, EventArgs e)
        {
            fullScr();
        }

        private void ViewPanel_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            fullScr();
        }

        private void muteButton_Click(object sender, EventArgs e)
        {
            myPlayer.Mute = !myPlayer.Mute;
            if (myPlayer.Mute == false)
                muteButton.ImageIndex = 1;
            else
                muteButton.ImageIndex = 3;
        }

        private void viewPanel_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;

            string [] s = e.Data.GetData(DataFormats.FileDrop) as string[];
            string E = s[0];
            if (!ex.Contains(Path.GetExtension(E), StringComparer.OrdinalIgnoreCase) )
            {
                viewPanel.BackColor = Color.FromArgb(255,75,0,0);
            }
            this.Opacity = 0.75;
        }

        private void viewPanel_DragDrop(object sender, DragEventArgs e)
        {
            string[] s = e.Data.GetData(DataFormats.FileDrop) as string[];
            string path = s[0];
            if (ex.Contains(Path.GetExtension(path), StringComparer.OrdinalIgnoreCase))
            {
                loadFile(path);
            }
            this.Opacity = 1;
            viewPanel.BackColor = Color.Black;

        }
        private void viewPanel_DragLeave(object sender, EventArgs e)
        {
            this.Opacity = 1;
            if (viewPanel.BackColor != Color.Black)
                viewPanel.BackColor = Color.Black;
        }

        private void buttonHoverOn(object sender, EventArgs e)
        {
            Button b = sender as Button;
            switch(b.ImageIndex)
            {
                case 0: b.ImageIndex = 1; break ;
                case 2: b.ImageIndex = 3; break;
            }
        }
        private void buttonHoverOut(object sender, EventArgs e)
        {
            Button b = sender as Button;
            switch (b.ImageIndex)
            {
                case 1: b.ImageIndex = 0; break;
                case 3: b.ImageIndex = 2; break;
            }
        }

        private void playlistButton_Click(object sender, EventArgs e)
        {
            if (isPlaylistOpen == false)
            {
                playL.Show();
                isPlaylistOpen = true;
                playlistButton.Text = "Apply";
                nextButton.Visible = false;
            }
            else
            {
                playlistButton.Text = "Playlist";
                playL.Hide();
                isPlaylistOpen = false;
                files = playL.nameList;
                filesToPlay = (files.Count());
                if (filesToPlay > 1)
                    nextButton.Visible = true;
                PlayNext();
            }
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            if (filesToPlay != -1)
                PlayNext();


        }
    }
}
