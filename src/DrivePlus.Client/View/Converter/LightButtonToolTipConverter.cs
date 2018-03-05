using System;
using System.Windows.Data;

namespace DrivePlus.Client.View.Converter
{
    public class LightButtonToolTipConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var isLightOn = value != null && (bool)value;
            return isLightOn ? "Licht ausschalten" : "Licht anschalten";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
