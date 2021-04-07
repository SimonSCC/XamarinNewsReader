using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIKit;
using XamarinNewsReader.iOS;

[assembly: Xamarin.Forms.Dependency(typeof(PlatformLabel))]

namespace XamarinNewsReader.iOS
{
    public class PlatformLabel : IPlatformLabel
    {
        public PlatformLabel() { }

        public string GetLabel()
        {
            return "IOS";
        }



        public string GetLabel(string additionalLabel)
        {
            return additionalLabel + "IOS";
        }

        public string GetLabel(string additionalLabel, bool addVersion)
        {
            string label = (addVersion) ? label = $"{additionalLabel} IOS {GetOsVersion()}" : $"{additionalLabel} IOS";
            return label;
        }

        private object GetOsVersion()
        {
            return UIDevice.CurrentDevice.SystemVersion;
        }
    }
}
