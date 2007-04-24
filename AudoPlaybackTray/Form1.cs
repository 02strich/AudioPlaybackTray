using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AudoPlaybackTray
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Hide();
        }

        public static List<String> getDevices()
        {
        }

        public static bool setDefaultPlaybackDevice(String deviceName)
        {
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            while (contextMenuStrip1.Items.Count>2)
            {
                //contextMenuStrip1.Items[0].Click -= 
                contextMenuStrip1.Items.RemoveAt(0);
            }
            ToolStripItem item = new ToolStripMenuItem();
            item.Click += new EventHandler(mnu_Device_Click);
            item.Text = DateTime.Now.ToLongTimeString();
            contextMenuStrip1.Items.Insert(0, item);
        }

        private void mnu_Device_Click(object sender, EventArgs e)
        {
            MessageBox.Show(sender.ToString());
        }

        private void mnu_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}