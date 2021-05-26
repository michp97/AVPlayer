using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using PVS.MediaPlayer;

namespace AVPlayer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (!Player.MFPresent)
            {
                MessageBox.Show("Error!\n\nMediaFoundation is not installed!\n\n Please install it before you run AVPlayer");
                System.Diagnostics.Process.Start("https://www.microsoft.com/en-us/software-download/mediafeaturepack");
            }
            else
                Application.Run(new playerWindow());
        }
    }
}
