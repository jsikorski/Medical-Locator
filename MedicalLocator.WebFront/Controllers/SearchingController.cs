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
using MedicalLocator.WebFront.Services;
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
            var viewModel = GetSearchDataViewModel();
            return PartialView("_SearchDialogPartial", viewModel);
        }

        public ActionResult Search(SearchDataViewModel searchDataViewModel)
        {
            if (!IsSearchDataViewModelValid(searchDataViewModel))
            {
                SetNotification(NotificationType.Error, "Some of the input data are invalid.");
                return FailureJsonResult();
            }

            IEnumerable<MedicalType> selectedMedicalTypes = searchDataViewModel.GetSelectedMedicalTypes();
            searchDataViewModel.SearchData.SearchedMedicalTypes = selectedMedicalTypes;

            SessionManager.LastSearchData = searchDataViewModel.SearchData;
            return ProcessCommandData(searchDataViewModel.SearchData, () => Json(LastCommandResult, JsonRequestBehavior.AllowGet));
        }

        private SearchDataViewModel GetSearchDataViewModel()
        {
            IEnumerable<CenterType> allCenterTypes = _enumsValuesProvider.GetAllCenterTypes();
            IEnumerable<MedicalType> allMedicalTypes = _enumsValuesProvider.GetAllMedicalTypes();

            SearchData lastSearchData = SessionManager.LastSearchData;
            if (lastSearchData != null)
            {
                return SearchDataViewModel.CreateUsingLastSearchData(allCenterTypes, allMedicalTypes, lastSearchData);
            }

            var medicalTypesDictionary = allMedicalTypes.ToDictionary(type => type, type => true);
            return new SearchDataViewModel(allCenterTypes, medicalTypesDictionary);
        }

        private bool IsSearchDataViewModelValid(SearchDataViewModel searchDataViewModel)
        {
            return ModelState.IsValid && searchDataViewModel.GetSelectedMedicalTypes().Any();
        }
    }
}
