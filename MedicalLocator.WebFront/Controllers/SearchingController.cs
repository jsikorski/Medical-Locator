using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using MedicalLocator.WebFront.Infrastructure;
using MedicalLocator.WebFront.Models;
using MedicalLocator.WebFront.Models.CommandsData;
using MedicalLocator.WebFront.ViewModels;

namespace MedicalLocator.WebFront.Controllers
{
    public class SearchingController : CommandsController
    {
        private readonly IEnumsValuesProvider _enumsValuesProvider;

        public SearchingController(IEnumsValuesProvider enumsValuesProvider)
        {
            _enumsValuesProvider = enumsValuesProvider;
        }

        public ActionResult FindNearby(double longitude, double latitude)
        {
            var findNearbyData = new FindNearbyData(longitude, latitude);
            return ProcessCommandData(findNearbyData, () => Json(LastCommandResult, JsonRequestBehavior.AllowGet));
        }

        public ActionResult ShowSearchDialog()
        {
            var allCenterTypes = _enumsValuesProvider.GetAllCenterTypes();
            var allMedicalTypes = _enumsValuesProvider.GetAllMedicalTypes();
            var medicalTypesDictionary = allMedicalTypes.ToDictionary(type => type, type => true);

            var viewModel = new SearchDataViewModel(allCenterTypes, medicalTypesDictionary);
            return PartialView("_SearchDialogPartial", viewModel);
        }

        public ActionResult Search(SearchDataViewModel searchDataViewModel)
        {
            var searchedMedicalTypes = searchDataViewModel.MedicalTypesDictionary.Where(pair => pair.Value).Select(pair => pair.Key);
            searchDataViewModel.SearchData.SearchedMedicalTypes = searchedMedicalTypes;
            return ProcessCommandData(searchDataViewModel.SearchData, () => null);
        }
    }
}
