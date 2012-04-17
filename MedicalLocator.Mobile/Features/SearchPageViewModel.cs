using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Caliburn.Micro;
using MedicalLocator.Mobile.Commands;
using MedicalLocator.Mobile.DatabaseConnectionReference;
using MedicalLocator.Mobile.Infrastructure;
using MedicalLocator.Mobile.Model;
using IContainer = Autofac.IContainer;
using MedicalType = MedicalLocator.Mobile.DatabaseConnectionReference.MedicalType;

namespace MedicalLocator.Mobile.Features
{
    public class SearchPageViewModel : Screen
    {
        private readonly CurrentContext _currentContext;
        private readonly IEnumsValuesProvider _enumsValuesProvider;
        private readonly IContainer _container;

        public int SearchingRange
        {
            get { return _currentContext.LoggedInUserModel.LastSearch.Range; }
            set { _currentContext.LoggedInUserModel.LastSearch.Range = value; }
        }

        public IEnumerable<CenterType> PossibleSearchingCenterTypes { get; set; }
        public int SelectedCenterTypeIndex
        {
            get { return PossibleSearchingCenterTypes.ToList().IndexOf(_currentContext.LoggedInUserModel.LastSearch.CenterType); }
            set { _currentContext.LoggedInUserModel.LastSearch.CenterType = PossibleSearchingCenterTypes.ElementAt(value); }
        }

        public string SearchedAddress
        {
            get { return _currentContext.LoggedInUserModel.LastSearch.Address; }
            set { _currentContext.LoggedInUserModel.LastSearch.Address = value; }
        }

        public double SearchedLatitude
        {
            get { return _currentContext.LoggedInUserModel.LastSearch.Latitude; }
            set { _currentContext.LoggedInUserModel.LastSearch.Latitude = value; }
        }

        public double SearchedLongitude
        {
            get { return _currentContext.LoggedInUserModel.LastSearch.Longitude; }
            set { _currentContext.LoggedInUserModel.LastSearch.Longitude = value; }
        }

        public IEnumerable<SearchedObjectViewModel> PossibleSearchedTypes { get; private set; }

        public SearchPageViewModel(
            CurrentContext currentContext, 
            IEnumsValuesProvider enumsValuesProvider, 
            IContainer container)
        {
            _currentContext = currentContext;
            _enumsValuesProvider = enumsValuesProvider;
            _container = container;

            PossibleSearchingCenterTypes = _enumsValuesProvider.GetAllCenterTypes();
        }

        public void Search()
        {
            var command = _container.Resolve<Search>();
            CommandInvoker.Invoke(command);
        }

        protected override void OnActivate()
        {
            IEnumerable<MedicalType> allMedicalTypes = _enumsValuesProvider.GetAllMedicalTypes();
            PossibleSearchedTypes = allMedicalTypes.Select(
                type => SearchedObjectViewModel.CreateUsingContext(type, _currentContext)).ToList();
        }

        protected override void OnDeactivate(bool close)
        {
        ////    _currentContext.SelectedSearchedObjects = PossibleSearchedTypes.Where(vm => vm.IsSelected).Select(vm => vm.MedicalType);
            base.OnDeactivate(close);
        }
    }
}