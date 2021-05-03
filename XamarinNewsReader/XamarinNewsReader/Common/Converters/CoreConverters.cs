using System;
using System.Globalization;
using Xamarin.Forms;

namespace XamarinNewsReader.Common.Converters
{

    public class SelectedItemConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var eventArgs = value as SelectedItemChangedEventArgs;
            return eventArgs.SelectedItem;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public sealed class LabelFontWeightConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo language)
        {
            return ((string)value + "").Contains("Trump") ? FontAttributes.Bold : FontAttributes.None;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo language)
        {
            return null;
        }
    }
    public sealed class AgoLabelConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo language)
        {
            DateTime articleDateTime = (DateTime)value;
            int minDifference = (int)(DateTime.Now - articleDateTime).TotalMinutes;

            return (minDifference > 60) ? "more than an hour ago" : Math.Abs(minDifference) + " minutes ago";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
