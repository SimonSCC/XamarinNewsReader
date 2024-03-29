﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinNewsReader.Effects
{
    public static class CustomFontEffect
    {
        class FontEffect : RoutingEffect
        {
            public FontEffect() : base("Xamarin.FontEffect")
            {
            }
        }

        public static readonly BindableProperty FontFileNameProperty = BindableProperty.CreateAttached("FontFileName", typeof(string), typeof(CustomFontEffect), "", propertyChanged: OnFileNameChanged);
        public static string GetFontFileName(BindableObject view)
        {
            return (string)view.GetValue(FontFileNameProperty);
        }

        public static void SetFontFileName(BindableObject view, string value)
        {
            view.SetValue(FontFileNameProperty, value);
        }
        static void OnFileNameChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as View;
            if (view == null)
            {
                return;
            }
            view.Effects.Add(new FontEffect());
        }


    }
}
