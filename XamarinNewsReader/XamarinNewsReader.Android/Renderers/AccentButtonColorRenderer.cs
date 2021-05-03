using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XamarinNewsReader.Droid.Renderers;

[assembly:ExportRenderer (typeof(Xamarin.Forms.Button) , typeof(AccentButtonColorRenderer))]
namespace XamarinNewsReader.Droid.Renderers
{
    [Obsolete]
    public class AccentButtonColorRenderer : ButtonRenderer 
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                var button = (Xamarin.Forms.Button)e.NewElement;
                button.BackgroundColor = AccentColor;
                button.TextColor = Color.White;
                button.FontAttributes = FontAttributes.Bold;
                button.BorderRadius = 22;

            }
        }

        private Color AccentColor
        {
            get
            {
                return XamarinNewsReader.Droid.Helpers.ColorHelper.PlatformColor;
            }
        }
    }
}
