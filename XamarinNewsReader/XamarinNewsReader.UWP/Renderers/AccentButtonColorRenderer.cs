using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;
using XamarinNewsReader.UWP.Renderers;

[assembly: ExportRenderer(typeof(Button), typeof(AccentButtonColorRenderer))]

namespace XamarinNewsReader.UWP.Renderers
{
    public class AccentButtonColorRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                var button = (Xamarin.Forms.Button)e.NewElement;
                button.BackgroundColor = AccentColor;
                button.TextColor = Color.White;
                button.FontAttributes = FontAttributes.Bold;
                button.CornerRadius = 22;

            }

        }
        private Color AccentColor
        {
            get
            {
                return XamarinNewsReader.UWP.Helpers.ColorHelper.PlatformColor;
            }
        }
    }
}
