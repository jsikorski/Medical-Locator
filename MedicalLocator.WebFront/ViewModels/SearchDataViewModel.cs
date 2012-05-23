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
            IDictionary<MedicalType, bool> medicalTypesDictionary,
            CurrentContext currentContext)
        {
            return new SearchDataViewModel(allCenterTypes, medicalTypesDictionary) { SearchData = currentContext.LastSearchData };
        }

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

        public IEnumerable<MedicalType> GetSelectedMedicalTypes()
        {
            return MedicalTypesDictionary.Where(pair => pair.Value).Select(pair => pair.Key).ToList();
        }
    }
}