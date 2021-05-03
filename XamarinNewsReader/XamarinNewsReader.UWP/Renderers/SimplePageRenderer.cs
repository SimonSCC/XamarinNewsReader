using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;
using XamarinNewsReader.UWP.Renderers;

[assembly: ExportRenderer (typeof(Xamarin.Forms.ContentPage), typeof(SimplePageRenderer))]
namespace XamarinNewsReader.UWP.Renderers
{
    public class SimplePageRenderer : PageRenderer 
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);
        }
    }
}
