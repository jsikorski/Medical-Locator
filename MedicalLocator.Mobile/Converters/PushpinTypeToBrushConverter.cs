using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using MedicalLocator.Mobile.BingMaps;
using MedicalLocator.Mobile.GoogleMapsInterfaceReference;
using MedicalLocator.Mobile.Model;

namespace MedicalLocator.Mobile.Converters
{
    public class PushpinTypeToBrushConverter : IValueConverter
    {
        private static readonly Brush UserPushpinBrush = new SolidColorBrush(Colors.Orange);

        private static readonly IDictionary<MedicalType, Brush> BrushesDictionary
            = new Dictionary<MedicalType, Brush>
                  {
                      {MedicalType.Doctor, new SolidColorBrush(Colors.Brown)},
                      {MedicalType.Dentist, new SolidColorBrush(Colors.Blue)},
                      {MedicalType.Health, new SolidColorBrush(Colors.Purple)},
                      {MedicalType.Hospital, new SolidColorBrush(Colors.Red)},
                      {MedicalType.Pharmacy, new SolidColorBrush(Colors.Green)},
                      {MedicalType.Physiotherapist, new SolidColorBrush(Colors.Cyan)}
                  };

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var pushpinType = (PushpinType)value;

            if (pushpinType == PushpinType.UserPushpin)
            {
                return UserPushpinBrush;
            }

            if (pushpinType.MedicalType != null)
            {
                return BrushesDictionary[pushpinType.MedicalType.Value];
            }

            return new SolidColorBrush(Colors.Transparent);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}