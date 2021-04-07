using Android.Runtime;
using Android.Speech.Tts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinNewsReader.Droid;
using XamarinNewsReader.Interfaces;


[assembly: Dependency(typeof(TextSpeecher))]
namespace XamarinNewsReader.Droid
{
    public class TextSpeecher : Java.Lang.Object, ITextSpeecher, TextToSpeech.IOnInitListener
    {
        TextToSpeech speaker;
        string toSpeak;
        public TextSpeecher() { }

       

        public void Speak(string text)
        {
            var ctx = Android.App.Application.Context;
            toSpeak = text;
            if (speaker == null)
            {
                speaker = new TextToSpeech(ctx, this);
                //var allAvailableLocales = Java.Util.Locale.GetAvailableLocales();
                //foreach (var item in allAvailableLocales)
                //{
                //    if (item.DisplayLanguage == "Danish")
                //    {
                //        speaker.SetLanguage(item);
                //        break;
                //    }
                //}
                
            }
            else
            {
                if (Android.OS.Build.VERSION.Release.StartsWith("4"))
                {
                    speaker.Speak(toSpeak, QueueMode.Flush, null);
                }
                else
                {
                    speaker.Speak(toSpeak, QueueMode.Flush, null, null);
                }
            }
        }

        #region IOnInitListener Implemenetation
        public void OnInit([GeneratedEnum] OperationResult status)
        {
            if (status.Equals(OperationResult.Success))
            {
                if (Android.OS.Build.VERSION.Release.StartsWith("4"))
                {
                    speaker.Speak(toSpeak, QueueMode.Flush, null);
                }
                else
                {
                    speaker.Speak(toSpeak, QueueMode.Flush, null, null);
                }
            }
        }
        #endregion
    }
}
