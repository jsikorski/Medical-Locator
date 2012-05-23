using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using MedicalLocator.WebFront.DatabaseConnectionReference;
using MedicalLocator.WebFront.Models;
using MedicalLocator.WebFront.Models.CommandsData;
using MedicalLocator.WebFront.Validation;

namespace MedicalLocator.WebFront.ViewModels
{
    public class SearchDataViewModel
    {
        public SearchData SearchData { get; set; }
        public IEnumerable<CenterType> AllCenterTypes { get; set; }
        public IDictionary<MedicalType, bool> MedicalTypesDictionary { get; set; }

        public static SearchDataViewModel CreateUsingContext(
            IEnumerable<CenterType> allCenterTypes,
            IEnumerable<MedicalType> allMedicalTypes,
            CurrentContext currentContext)
        {
            var medicalTypesDictionary 
                = allMedicalTypes.ToDictionary(type => type, type => WasMedicalTypeSelected(type, currentContext));

            return new SearchDataViewModel
                       {
                           SearchData = currentContext.LastSearchData,
                           AllCenterTypes = allCenterTypes,
                           MedicalTypesDictionary = medicalTypesDictionary
                       };
        }

        public SearchDataViewModel(
            IEnumerable<CenterType> allCenterTypes,
            IDictionary<MedicalType, bool> medicalTypesDictionary)
        {
            SearchData = new SearchData();

            AllCenterTypes = allCenterTypes;
            MedicalTypesDictionary = medicalTypesDictionary;
        }

        public IEnumerable<MedicalType> GetSelectedMedicalTypes()
        {
            return MedicalTypesDictionary.Where(pair => pair.Value).Select(pair => pair.Key).ToList();
        }

        // Constructor public for ASP binding
        public SearchDataViewModel()
        {
        }

        private static bool WasMedicalTypeSelected(MedicalType medicalType, CurrentContext currentContext)
        {
            return currentContext.LastSearchData.SearchedMedicalTypes.Contains(medicalType);
        }
    }
}