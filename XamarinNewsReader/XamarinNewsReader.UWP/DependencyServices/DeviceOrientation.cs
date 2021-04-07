using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.ViewManagement;
using XamarinNewsReader.Interfaces;
using XamarinNewsReader.UWP;

[assembly: Xamarin.Forms.Dependency(typeof(DeviceOrientation))]
namespace XamarinNewsReader.UWP
{
    public class DeviceOrientation : IDeviceOrientation
    {
        public DeviceOrientation()
        {

        }
        public DeviceOrientations GetOrientation()
        {
            var orientation = ApplicationView.GetForCurrentView().Orientation;
            if (orientation == ApplicationViewOrientation.Landscape)
            {
                return DeviceOrientations.Landscape;
            }
            else
            {
                return DeviceOrientations.Portrait;
            }
        }
    }
}
