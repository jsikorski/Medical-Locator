using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Data;
using MedicalLocator.Mobile.BingMaps;
using MedicalLocator.Mobile.GoogleMapsInterfaceReference;
using MedicalLocator.Mobile.Model;

namespace MedicalLocator.Mobile.Converters
{
    public class PushpinTypeToNameConverter : IValueConverter
    {
        private static readonly IDictionary<MedicalType, string> NamesDictionary = new Dictionary<MedicalType, string>
                                                                                       {
                                                                                           {MedicalType.Doctor, "Doctor"},
                                                                                           {MedicalType.Dentist, "Dentist"},
                                                                                           {MedicalType.Health, "Health"},
                                                                                           {MedicalType.Hospital, "Hospital"},
                                                                                           {MedicalType.Pharmacy, "Pharmacy"},
                                                                                           {MedicalType.Physiotherapist, "Physiotherapist"}
                                                                                       };

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var pushpinType = (PushpinType)value;

            if (pushpinType == PushpinType.UserPushpin)
            {
                return string.Empty;
            }

            if (pushpinType.MedicalType != null)
            {
                return NamesDictionary[pushpinType.MedicalType.Value];
            }

            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}