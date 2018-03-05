using System;
using System.Windows.Data;

namespace DrivePlus.Client.View.Converter
{
    public class LightButtonTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var isLightOn = value != null && (bool)value;
            return isLightOn ? "Licht ist an" : "Licht ist aus";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
