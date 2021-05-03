using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XamarinNewsReader.Droid.Effects;

[assembly: ResolutionGroupName("Xamarin")]
[assembly: ExportEffect(typeof(FocusEffect), "FocusEffect")]

namespace XamarinNewsReader.Droid.Effects
{
    public class FocusEffect : PlatformEffect
    {
        Android.Graphics.Color backgroundColor;

        protected override void OnAttached()
        {
            try
            {
                backgroundColor = XamarinNewsReader.Droid.Helpers.ColorHelper.PlatformAccentColor;
                Control.SetBackgroundColor(backgroundColor);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot set property on attached control. Error: ", ex.Message);
            }
        }

        protected override void OnDetached()
        {
        }

        protected override void OnElementPropertyChanged(System.ComponentModel.PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(args);
            try
            {
                if (args.PropertyName == "IsFocused")
                {
                    if (((Android.Graphics.Drawables.ColorDrawable)Control.Background).Color == backgroundColor)
                    {
                        Control.SetBackgroundColor(Android.Graphics.Color.White);
                        var nativeEditText = (global::Android.Widget.EditText)Control;
                        nativeEditText.SetSelectAllOnFocus(true);
                    }
                    else
                    {
                        Control.SetBackgroundColor(backgroundColor);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
