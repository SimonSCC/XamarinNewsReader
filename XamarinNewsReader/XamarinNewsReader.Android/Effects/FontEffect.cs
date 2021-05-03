using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Widget;
using Android.Graphics;
using System.ComponentModel;
using XamarinNewsReader.Droid.Effects;
using XamarinNewsReader.Effects;
//using XamarinNewsReader.Droid.Effects.More;

[assembly: ExportEffect(typeof(FontEffect), "FontEffect")]

namespace XamarinNewsReader.Droid.Effects
{
    public class FontEffect : PlatformEffect
    {
        TextView control;
        protected override void OnAttached()
        {
            try
            {
                control = Control as TextView;

                string fontPath = "Fonts/" + CustomFontEffect.GetFontFileName(Element) + ".ttf";

                Typeface font = Typeface.CreateFromAsset(Forms.Context.Assets, fontPath);
                control.Typeface = font;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot set property on attached control. Error: ", ex.Message);
            }
        }

        protected override void OnDetached()
        {
        }

        protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
        {
            if (args.PropertyName == CustomFontEffect.FontFileNameProperty.PropertyName)
            {
                Typeface font = Typeface.CreateFromAsset(Forms.Context.ApplicationContext.Assets, "Fonts/" + CustomFontEffect.GetFontFileName(Element) + ".ttf");
                control.Typeface = font;
            }
        }

    }
}
