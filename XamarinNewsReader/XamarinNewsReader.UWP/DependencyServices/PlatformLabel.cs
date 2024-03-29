﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinNewsReader.UWP;

[assembly: Xamarin.Forms.Dependency(typeof(PlatformLabel))]
namespace XamarinNewsReader.UWP
{
    public class PlatformLabel : IPlatformLabel
    {
        public PlatformLabel()
        {

        }
        public string GetLabel()
        {
            return "Windows";
        }
    

        public string GetLabel(string additionalLabel)
        {
            return additionalLabel + "Windows";
        }

        public string GetLabel(string additionalLabel, bool addVersion)
        {
            string label = (addVersion) ? label = $"{additionalLabel} Windows {GetOsVersion()}" : $"{additionalLabel} Windows";
            return label;
        }

        private string GetOsVersion()
        {
            var systemVersion = Windows.System.Profile.AnalyticsInfo.VersionInfo.DeviceFamilyVersion;

            ulong v = ulong.Parse(systemVersion);
            ulong v1 = (v & 0xFFFF000000000000L) >> 48;
            ulong v2 = (v & 0x0000FFFF00000000L) >> 32;
            ulong v3 = (v & 0x00000000FFFF0000L) >> 16;
            ulong v4 = (v & 0x000000000000FFFFL);
            string version = $"{v1}.{v2}.{v3}.{v4}";

            return version;
        }
    }
}
