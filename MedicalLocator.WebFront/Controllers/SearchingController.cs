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
        private readonly CurrentContext _currentContext;

        public SearchingController(IEnumsValuesProvider enumsValuesProvider, CurrentContext currentContext)
        {
            _enumsValuesProvider = enumsValuesProvider;
            _currentContext = currentContext;
        }

        public ActionResult FindNearby(double longitude, double latitude)
        {
            var findNearbyData = new FindNearbyData(longitude, latitude);
            return ProcessCommandData(findNearbyData, () => Json(LastCommandResult, JsonRequestBehavior.AllowGet));
        }

        public ActionResult ShowSearchDialog()
        {
            var viewModel = GetSearchDataViewModel();
            return PartialView("_SearchDialogPartial", viewModel);
        }

        public ActionResult Search(SearchDataViewModel searchDataViewModel)
        {
            if (!ModelState.IsValid)
            {
                //TODO: Check if it will be needed
            }

            IEnumerable<MedicalType> selectedMedicalTypes = searchDataViewModel.GetSelectedMedicalTypes();
            searchDataViewModel.SearchData.SearchedMedicalTypes = selectedMedicalTypes;
            
            _currentContext.UpdateLastSearchData(searchDataViewModel.SearchData);
            return ProcessCommandData(searchDataViewModel.SearchData, () => Json(LastCommandResult, JsonRequestBehavior.AllowGet));
        }

        private SearchDataViewModel GetSearchDataViewModel()
        {
            var allCenterTypes = _enumsValuesProvider.GetAllCenterTypes();
            var allMedicalTypes = _enumsValuesProvider.GetAllMedicalTypes();
            var medicalTypesDictionary = allMedicalTypes.ToDictionary(type => type, type => true);

            if (_currentContext.LastSearchData != null)
            {
                return SearchDataViewModel.CreateUsingContext(allCenterTypes, medicalTypesDictionary, _currentContext);
            }

            return new SearchDataViewModel(allCenterTypes, medicalTypesDictionary);
        }
    }
}
