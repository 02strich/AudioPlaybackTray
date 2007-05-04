using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AudoPlaybackTray
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            foreach (string t in args)
                Console.WriteLine(t);

            Form1 frm = new Form1();

            Arguments param = new Arguments(args);
            if (param["help"] != null)
            {
                // print help
            }
            else if (param["listPlayback"] != null)
            {
                string tmp = "";
                foreach (string dev in frm.getPlaybackDevices())
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
                    string tmp = frm.getDefaultPlaybackDevice();
                    frm.setDefaultPlaybackDevice(param["setDefaultPlayback"]);
                    string tmp2 = param["forApplication"];
                    System.Diagnostics.Process.Start(param["forApplication"]);
                    System.Threading.Thread.Sleep(1000 * 20);
                    frm.setDefaultPlaybackDevice(tmp);
                }
                else
                {
                    frm.setDefaultPlaybackDevice(param["setDefaultPlayback"]);
                }                
            }
            else if (param["getDefaultPlayback"] != null)
            {
                MessageBox.Show(frm.getDefaultPlaybackDevice());
            }
            else
            {
                //Application.EnableVisualStyles();
                //Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(frm);
            }
        }
    }
}