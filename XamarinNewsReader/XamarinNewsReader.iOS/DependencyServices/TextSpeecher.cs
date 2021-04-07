using System;
using System.Collections.Generic;
using System.Text;
using AVFoundation;
using XamarinNewsReader.Interfaces;
using XamarinNewsReader.iOS;

[assembly: Xamarin.Forms.Dependency(typeof(TextSpeecher))]
namespace XamarinNewsReader.iOS
{
    public class TextSpeecher : ITextSpeecher
    {
        public TextSpeecher() { }

        public void Speak(string text)
        {
            var speechSynthesizer = new AVSpeechSynthesizer();
            var speechUtterance = new AVSpeechUtterance(text)
            {
                Rate = AVSpeechUtterance.MaximumSpeechRate / 4,
                Voice = AVSpeechSynthesisVoice.FromLanguage("en-US"),
                Volume = 0.5f,
                PitchMultiplier = 1.0f
            };

            speechSynthesizer.SpeakUtterance(speechUtterance);
        }
    }
}