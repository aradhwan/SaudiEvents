using System;
using System.Globalization;
using Xamarin.Forms;
using SaudiEvents.Util;

namespace SaudiEvents.Converters
{
    public class WebImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var imageUrl = (value ?? "").ToString();
            if (string.IsNullOrEmpty(imageUrl))
                return null;

            return ImageSource.FromUri(new Uri(ServerURL.GetURL() + imageUrl));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException($"{nameof(WebImageConverter)} cannot be used on two-way bindings.");
        }
    }
}
