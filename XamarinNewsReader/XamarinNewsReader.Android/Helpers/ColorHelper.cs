using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinNewsReader.Droid.Helpers
{
    public static class ColorHelper
    {
        public static Android.Graphics.Color PlatformAccentColor
        {
            get
            {
                return Android.Graphics.Color.Argb(255, 142, 198, 63);
            }
        }

        public static Xamarin.Forms.Color PlatformColor
        {
            get
            {
                return Xamarin.Forms.Color.FromHex("#8EC63F");
            }
        }
    }
}
