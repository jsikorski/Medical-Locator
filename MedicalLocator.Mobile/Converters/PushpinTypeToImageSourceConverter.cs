﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;
using MedicalLocator.Mobile.BingMaps;
using MedicalLocator.Mobile.GoogleMapsInterfaceReference;
using MedicalLocator.Mobile.Model;

namespace MedicalLocator.Mobile.Converters
{
    public class PushpinTypeToImageSourceConverter : IValueConverter
    {
        private const string PushpinImagesSourceBase = @"/MedicalLocator.Mobile;component/Graphics/Pushpins/";
        private const string UserPushpinImageSource = PushpinImagesSourceBase + "user.png";
        private readonly IDictionary<MedicalType, string> _fileNamesDictionary
            = new Dictionary<MedicalType, string>
                  {
                      {MedicalType.Doctor, "doctor.png"},
                      {MedicalType.Dentist, "dentist.png"},
                      {MedicalType.Health, "health.png"},
                      {MedicalType.Hospital, "hospital.png"},
                      {MedicalType.Pharmacy, "pharmacy.png"},
                      {MedicalType.Physiotherapist, "physiotherapist.png"}
                  };

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var pushpinType = (PushpinType)value;
            if (pushpinType == PushpinType.UserPushpin)
            {
                return UserPushpinImageSource;
            }

            if (pushpinType.MedicalType != null)
            {
                string fileName = _fileNamesDictionary[pushpinType.MedicalType.Value];
                string source = PushpinImagesSourceBase + fileName;
                return source;
            }

            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}