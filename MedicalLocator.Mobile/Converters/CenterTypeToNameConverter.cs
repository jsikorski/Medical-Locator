using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;
using MedicalLocator.Mobile.Model;
using MedicalLocator.Mobile.ServicesReferences;

namespace MedicalLocator.Mobile.Converters
{
    public class CenterTypeToNameConverter : IValueConverter
    {
        private readonly IDictionary<CenterType, string> _namesDictionary = new Dictionary<CenterType, string>
                                                                                {
                                                                                    {CenterType.MyLocation, "My location"}, 
                                                                                    {CenterType.Address, "Address"},
                                                                                    {CenterType.Coordinates, "Coordinates"}
                                                                                };

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
            var typedValue = (CenterType) value;
            return _namesDictionary[typedValue];
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}