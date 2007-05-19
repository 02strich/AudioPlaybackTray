using System;
using System.Collections.Generic;
using System.Text;
//using Microsoft.DirectX.DirectSound;
using WaveLib.AudioMixer;

namespace AudioPlaybackTray
{
    class PlaybackDevice
    {
        private List<string> devList;
        private Microsoft.Win32.RegistryKey regKey;
        private string defaultPlayback = "";
        //private DevicesCollection devColl;
        private Mixers mMixers;

        public PlaybackDevice()
        {
            devList = new List<string>();
            regKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Multimedia\Sound Mapper", true);
            if (regKey == null)
                regKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Multimedia", true).CreateSubKey("Sound Mapper");
            defaultPlayback = regKey.GetValue("Playback") as string;
            
            /*devColl = new DevicesCollection();
            foreach (DeviceInformation dev in devColl)
            {
                if (dev.ModuleName == "")
                    continue;

                devList.Insert(0, dev.Description);
            }*/

            mMixers = new Mixers();
            foreach (MixerDetail mixerDetail in mMixers.Playback.Devices)
                devList.Add(mixerDetail.MixerName);
        }

        public string[] getPlaybackDevices()
        {
            return devList.ToArray(); ;
        }

        public bool setDefaultPlaybackDevice(string deviceName)
        {
            regKey.SetValue("Playback", deviceName, Microsoft.Win32.RegistryValueKind.String);
            defaultPlayback = deviceName;
            return true;
        }

        public string getDefaultPlaybackDevice()
        {
            return defaultPlayback;
        }

        // Singleton Pattern
        private static PlaybackDevice _singletonDevice = null;
        public static PlaybackDevice getInstance()
        {
            if (_singletonDevice == null)
            {
                _singletonDevice = new PlaybackDevice();
            }
            return _singletonDevice;
        }
    }
}
