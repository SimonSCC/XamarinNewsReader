using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinNewsReader.Interfaces;

namespace XamarinNewsReader.Helpers
{
    public static class GeneralHelper
    {
        //getLabel start
        public static string Getlabel()
        {
           string label = Xamarin.Forms.DependencyService.Get<IPlatformLabel>().GetLabel();
            return label;
        }

        public static string Getlabel(string additionalLabel)
        {
            string label = DependencyService.Get<IPlatformLabel>().GetLabel(additionalLabel);
            return label;
        }

        public static string Getlabel(string additionalLabel, bool addVersion)
        {
            string label = DependencyService.Get<IPlatformLabel>().GetLabel(additionalLabel, addVersion);
            return label;
        }

        //GetLabel ENd
        //GetOrientation Start
        public static DeviceOrientations GetOrientation()
        {
            var orientation = DependencyService.Get<IDeviceOrientation>().GetOrientation();
            return orientation;
        }


        //TextSpeecher Start
        public static void Speak(string text)
        {
            DependencyService.Get<ITextSpeecher>().Speak(text);
        }
    }
}
