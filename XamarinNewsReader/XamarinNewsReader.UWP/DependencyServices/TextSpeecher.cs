﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.SpeechSynthesis;
using Windows.UI.Xaml.Controls;
using Xamarin.Forms;
using XamarinNewsReader.Interfaces;
using XamarinNewsReader.UWP;

[assembly: Dependency(typeof(TextSpeecher))]
namespace XamarinNewsReader.UWP
{
    public class TextSpeecher : ITextSpeecher
    {
        public async void Speak(string text)
        {
            var mediaElement = new MediaElement();
            var synth = new SpeechSynthesizer();
            var stream = await synth.SynthesizeTextToStreamAsync(text);
            

            mediaElement.SetSource(stream, stream.ContentType);
            mediaElement.Play();
            }
    }
}
