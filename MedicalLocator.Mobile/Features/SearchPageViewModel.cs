using System.Collections.Generic;
using System.Linq;
using Autofac;
using Caliburn.Micro;
using MedicalLocator.Mobile.Commands;
using MedicalLocator.Mobile.Infrastructure;
using MedicalLocator.Mobile.Model;
using MedicalLocator.Mobile.Services;
using MedicalLocator.Mobile.ServicesReferences;

namespace MedicalLocator.Mobile.Features
{
    public class SearchPageViewModel : Screen
    {
        private readonly CurrentContext _currentContext;
        private readonly IEnumsValuesProvider _enumsValuesProvider;
        private readonly IContainer _container;

        public int Range
        {
            get { return _currentContext.Range; }
            set { _currentContext.Range = value; }
        }

        public IEnumerable<CenterType> CenterTypes { get; set; }
        public int SelectedCenterTypeIndex
        {
            get { return CenterTypes.ToList().IndexOf(_currentContext.CenterType); }
            set { _currentContext.CenterType = CenterTypes.ElementAt(value); }
        }

        public string Address
        {
            get { return _currentContext.Address; }
            set { _currentContext.Address = value; }
        }

        public double Longitude
        {
            get { return _currentContext.Longitude; }
            set { _currentContext.Longitude = value; }
        }

        public double Latitude
        {
            get { return _currentContext.Latitude; }
            set { _currentContext.Latitude = value; }
        }

        public IEnumerable<SearchedObjectViewModel> PossibleSearchedObjects { get; private set; }

        public SearchPageViewModel(
            CurrentContext currentContext, 
            IEnumsValuesProvider enumsValuesProvider, 
            IContainer container)
        {
            _currentContext = currentContext;
            _enumsValuesProvider = enumsValuesProvider;
            _container = container;

            CenterTypes = _enumsValuesProvider.GetAllCenterTypes();
        }

        public void BeginSearch()
        {
            var command = _container.Resolve<BeginSearch>();
            CommandInvoker.Execute(command);
        }

        protected override void OnActivate()
        {
            IEnumerable<MedicalType> allMedicalTypes = _enumsValuesProvider.GetAllMedicalTypes();
            PossibleSearchedObjects = allMedicalTypes.Select(
                type => SearchedObjectViewModel.CreateUsingContext(type, _currentContext)).ToList();
        }

        protected override void OnDeactivate(bool close)
        {
            _currentContext.SearchedObjects = PossibleSearchedObjects.Where(vm => vm.IsSelected).Select(vm => vm.MedicalType);
            base.OnDeactivate(close);
        }
    }
}