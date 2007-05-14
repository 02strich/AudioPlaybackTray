using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AudoPlaybackTray
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            foreach (string t in args)
                Console.WriteLine(t);

            Arguments param = new Arguments(args);
            if (param["help"] != null)
            {
                // print help
            }
            else if (param["listPlayback"] != null)
            {
                string tmp = "";
                foreach (string dev in PlaybackDevice.getInstance().getPlaybackDevices())
                {
                    tmp += dev;
                    tmp += "\n";
                }
                MessageBox.Show(tmp);
            }
            else if (param["setDefaultPlayback"] != null)
            {
                if (param["forApplication"] != null)
                {
                    string tmp = PlaybackDevice.getInstance().getDefaultPlaybackDevice();
                    PlaybackDevice.getInstance().setDefaultPlaybackDevice(param["setDefaultPlayback"]);
                    string tmp2 = param["forApplication"];
                    System.Diagnostics.Process.Start(param["forApplication"]);
                    System.Threading.Thread.Sleep(1000 * 20);
                    PlaybackDevice.getInstance().setDefaultPlaybackDevice(tmp);
                }
                else
                {
                    PlaybackDevice.getInstance().setDefaultPlaybackDevice(param["setDefaultPlayback"]);
                }                
            }
            else if (param["getDefaultPlayback"] != null)
            {
                MessageBox.Show(PlaybackDevice.getInstance().getDefaultPlaybackDevice());
            }
            else
            {
                //Application.EnableVisualStyles();
                //Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
        }
    }
}