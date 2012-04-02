using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace MedicalLocator.Mobile.Converters
{
    public class CenterTypeToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var typedValue = (string) value;
            var typedParamater = (string) parameter;

            if (typedValue == typedParamater)
            {
                return Visibility.Visible;
            }

            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new object();
            throw new NotImplementedException();
        }
    }
}