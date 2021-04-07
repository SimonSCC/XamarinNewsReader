using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinNewsReader.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(PlatformLabel))]
namespace XamarinNewsReader.Droid
{
    public class PlatformLabel : IPlatformLabel
    {
        public PlatformLabel() { }

        public static void Init()
        {
        }
        public string GetLabel()
        {
            return "Android";
        }
        public string GetLabel(string additionalLabel)
        {
            return additionalLabel + "Android";
        }

        public string GetLabel(string additionalLabel, bool addVersion)
        {
            string label = (addVersion) ? label = $"{additionalLabel} Android {GetOsVersion()}" : $"{additionalLabel} Android";
            return label;
        }

        private string GetOsVersion()
        {
            return Android.OS.Build.VERSION.Release;
        }
    }
}
