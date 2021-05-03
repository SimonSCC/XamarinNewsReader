using System;
using System.Collections.Generic;
using XamarinNewsReader.UWP.Effects;
using Windows.UI;
using Windows.UI.Xaml.Media;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;
using System.ComponentModel;

[assembly: ResolutionGroupName("Xamarin")]
[assembly: ExportEffect(typeof(FocusEffect), "FocusEffect")]
namespace XamarinNewsReader.UWP.Effects
{
    public class FocusEffect : PlatformEffect
    {
        Windows.UI.Color backgroundColor;

        protected override void OnAttached()
        {
            try
            {
                backgroundColor = Helpers.ColorHelper.PlatformAccentColor;

                (Control as Windows.UI.Xaml.Controls.Control).Background = new Windows.UI.Xaml.Media.SolidColorBrush(Windows.UI.Colors.White);
                (Control as FormsTextBox).BackgroundFocusBrush = new Windows.UI.Xaml.Media.SolidColorBrush(backgroundColor);

            }
            catch (Exception ex)
            {

            }
        }
        protected override void OnDetached()
        {
        }

        protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(args);
            try
            {
                if (args.PropertyName == "IsFocused")
                {
                    if (((Control as FormsTextBox).BackgroundFocusBrush as Windows.UI.Xaml.Media.SolidColorBrush).Color == backgroundColor)
                    {
                        (Control as FormsTextBox).SelectAll();
                    }
                    else
                    {

                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
    }

}
