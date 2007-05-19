using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AudioPlaybackTray
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            foreach (string dev in PlaybackDevice.getInstance().getPlaybackDevices())
            {
                ToolStripMenuItem item = new ToolStripMenuItem();
                item.Click += new EventHandler(mnu_Device_Click);
                item.Text = dev;
                if (dev == PlaybackDevice.getInstance().getDefaultPlaybackDevice())
                {
                    item.Checked = true;
                }
                contextMenuStrip1.Items.Insert(0, item);
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Hide();
        }

        private void mnu_Device_Click(object sender, EventArgs e)
        {
            PlaybackDevice.getInstance().setDefaultPlaybackDevice(sender.ToString());
        }

        private void mnu_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}