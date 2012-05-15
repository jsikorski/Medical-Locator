using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MedicalLocator.WebFront.DatabaseConnectionReference;
using MedicalLocator.WebFront.Models;
using MedicalLocator.WebFront.Models.CommandsData;

namespace MedicalLocator.WebFront.ViewModels
{
    public class SearchDataViewModel
    {
        public SearchData SearchData { get; set; }
        public IEnumerable<CenterType> AllCenterTypes { get; set; }
        public IDictionary<MedicalType, bool> MedicalTypesDictionary { get; set; }

        public SearchDataViewModel()
        {
        }

        public SearchDataViewModel(
            IEnumerable<CenterType> allCenterTypes,
            IDictionary<MedicalType, bool> medicalTypesDictionary)
        {
            SearchData = new SearchData();

            AllCenterTypes = allCenterTypes;
            MedicalTypesDictionary = medicalTypesDictionary;
        }
    }
}