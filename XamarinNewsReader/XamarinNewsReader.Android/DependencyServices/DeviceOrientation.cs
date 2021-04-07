using Android.Content;
using Android.Runtime;
using Android.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinNewsReader.Droid;
using XamarinNewsReader.Interfaces;

[assembly: Xamarin.Forms.Dependency(typeof(DeviceOrientation))]

namespace XamarinNewsReader.Droid
{
    public class DeviceOrientation : IDeviceOrientation
    {
      
        public static void Init()
        {

        }
        public DeviceOrientations GetOrientation()
        {
            IWindowManager windowManager = Android.App.Application.Context.GetSystemService(Context.WindowService).JavaCast<IWindowManager>();

            var rotation = windowManager.DefaultDisplay.Rotation;
            bool isLandscape = rotation == SurfaceOrientation.Rotation90 || rotation == SurfaceOrientation.Rotation270;
            return isLandscape ? DeviceOrientations.Landscape : DeviceOrientations.Portrait;

        }
    }
}
