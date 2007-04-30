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
                frm.setDefaultPlaybackDevice(param["setPlayback"]);
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