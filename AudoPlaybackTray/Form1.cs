using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.DirectX.DirectSound;

namespace AudoPlaybackTray
{
    public partial class Form1 : Form
    {
        List<string> devList;
        Microsoft.Win32.RegistryKey regKey;
        string defaultPlayback = "";
        DevicesCollection devColl;

        public Form1()
        {
            InitializeComponent();
            devList = new List<string>();
            devColl = new DevicesCollection();
            regKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Multimedia\Sound Mapper", true);
            if(regKey == null)
                regKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Multimedia", true).CreateSubKey("Sound Mapper");
            defaultPlayback = regKey.GetValue("Playback") as string;

            foreach (DeviceInformation dev in devColl)
            {
                if (dev.ModuleName == "")
                    continue;

                devList.Insert(0, dev.Description);
                ToolStripMenuItem item = new ToolStripMenuItem();
                item.Click += new EventHandler(mnu_Device_Click);
                item.Text = dev.Description;
                if (dev.Description == defaultPlayback)
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

        public string[] getPlaybackDevices()
        {
            return devList.ToArray(); ;
        }

        public bool setDefaultPlaybackDevice(string deviceName)
        {
            regKey.SetValue("Playback", deviceName, Microsoft.Win32.RegistryValueKind.String);
            defaultPlayback = deviceName;
            foreach (ToolStripItem item in contextMenuStrip1.Items)
            {
                try {
                    ToolStripMenuItem item2 = item as ToolStripMenuItem;
                    if (item2.Text == deviceName)
                        item2.Checked = true;
                    else
                        item2.Checked = false;
                } catch(Exception) {
                    continue;
                }
            }
            return true;
        }

        public string getDefaultPlaybackDevice()
        {
            return defaultPlayback;
        }

        private void mnu_Device_Click(object sender, EventArgs e)
        {
            setDefaultPlaybackDevice(sender.ToString());
        }

        private void mnu_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}