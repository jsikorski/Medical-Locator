using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;
using MedicalLocator.Mobile.Model;
using System.Linq;

namespace MedicalLocator.Mobile.Converters
{
    public class CenterTypesToNamesConverter : IValueConverter
    {
        private readonly IDictionary<CenterType, string> _namesDictionary = new Dictionary<CenterType, string>
                                                                                {
                                                                                    {CenterType.MyLocation, "My location"}, 
                                                                                    {CenterType.Address, "Address"},
                                                                                    {CenterType.Coordinates, "Coordinates"}
                                                                                };

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var typesList = (List<CenterType>) value;
            return typesList.Select(type => _namesDictionary[type]);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}