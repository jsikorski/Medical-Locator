using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MedicalLocator.WebFront.Infrastructure;
using MedicalLocator.WebFront.Validation;

namespace MedicalLocator.WebFront.Models.CommandsData
{
    public class SearchData : ICommandData
    {
        private const int DefaultSearchingRange = 2500;
        private const double DefaultSearchedLatitude = 0.0;
        private const double DefaultSearchedLongitude = 0.0;

        public double UserLatitude { get; set; }
        public double UserLongitude { get; set; }

        [DisplayName("Range")]
        [Range(1, 50000)]
        [Required]
        public int SearchingRange { get; set; }

        [DisplayName("Center type")]
        public CenterType CenterType { get; set; }

        [DisplayName("Address")]
        public string SearchedAddress { get; set; }

        [StatusCheckAge]
        public string Test { get; set; }

        [DisplayName("Latitude")]
        [RequiredIfPropertyEqual("CenterType", CenterType.Coordinates)]
        [Range(-180.0, 180.0)]
        public double SearchedLatitude { get; set; }

        [DisplayName("Longitude")]
        //[RequiredIfPropertyEqual("CenterType", CenterType.Coordinates)]
        [Range(-180.0, 180.0)]
        public double SearchedLongitude { get; set; }

        public IEnumerable<MedicalType> SearchedMedicalTypes { get; set; }

        public SearchData()
        {
            SearchingRange = DefaultSearchingRange;
            SearchedLatitude = DefaultSearchedLatitude;
            SearchedLongitude = DefaultSearchedLongitude;
        }
    }
}