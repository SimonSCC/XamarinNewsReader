using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIKit;
using XamarinNewsReader.Interfaces;
using XamarinNewsReader.iOS;

[assembly: Xamarin.Forms.Dependency(typeof(DeviceOrientation))]
namespace XamarinNewsReader.iOS
{
    public class DeviceOrientation : IDeviceOrientation
    {
        public DeviceOrientation()
        {

        }
        public DeviceOrientations GetOrientation()
        {
            var currentOrientation = UIApplication.SharedApplication.StatusBarOrientation;
            bool isPortrait = currentOrientation == UIInterfaceOrientation.Portrait || currentOrientation == UIInterfaceOrientation.PortraitUpsideDown;
            return isPortrait ? DeviceOrientations.Portrait : DeviceOrientations.Landscape;
        }
    }
}
