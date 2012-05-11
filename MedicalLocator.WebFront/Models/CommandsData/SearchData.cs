using System.Collections.Generic;
using System.ComponentModel;
using MedicalLocator.WebFront.Infrastructure;

namespace MedicalLocator.WebFront.Models.CommandsData
{
    public class SearchData : ICommandData
    {
        public double UserLatitude { get; set; }
        public double UserLongitude { get; set; }

        [DisplayName("Range")]
        [DefaultValue(2500)]
        public int Range { get; set; }
        [DisplayName("Center type")]
        public CenterType CenterType { get; set; }

        [DisplayName("Address")]
        public string SearchedAddress { get; set; }
        [DisplayName("Latitude")]
        public double SearchedLatitude { get; set; }
        [DisplayName("Longitude")]
        public double SearchedLongitude { get; set; }

        public IEnumerable<MedicalType> SearchedMedicalTypes { get; set; }
    }
}