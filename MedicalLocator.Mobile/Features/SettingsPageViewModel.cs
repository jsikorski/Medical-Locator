using System.Collections.Generic;
using Caliburn.Micro;
using MedicalLocator.Mobile.Model;
using MedicalLocator.Mobile.ServicesReferences;
using System.Linq;

namespace MedicalLocator.Mobile.Features
{
    public class SettingsPageViewModel : Screen
    {
        private readonly CurrentContext _currentContext;

        public bool AreLocationServicesAllowed
        {
            get { return _currentContext.AreLocationServicesAllowed; }
            set
            {
                _currentContext.AreLocationServicesAllowed = value;
            }
        }
        public int Range
        {
            get { return _currentContext.Range; }
            set { _currentContext.Range = value; }
        }
        public IEnumerable<CenterType> CenterTypes { get; set; }
        public CenterType SelectedCenterType
        {
            get { return _currentContext.CenterType; }
            set { _currentContext.CenterType = value; }
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

        public IEnumerable<SearchedObjectViewModel> SearchedObjects { get; private set; }

        public SettingsPageViewModel(CurrentContext currentContext)
        {
            _currentContext = currentContext;
            CenterTypes = new List<CenterType> { CenterType.MyLocation, CenterType.Address, CenterType.Coordinates };
        }

        protected override void OnActivate()
        {
            SearchedObjects = new List<SearchedObjectViewModel>
                                  {
                                      SearchedObjectViewModel.CreateUsingContext(MedicalType.Dentist, _currentContext),
                                      SearchedObjectViewModel.CreateUsingContext(MedicalType.Doctor, _currentContext),
                                  };
        }

        protected override void OnDeactivate(bool close)
        {
            _currentContext.SearchedObjects = SearchedObjects.Where(vm => vm.IsSelected).Select(vm => vm.MedicalType);
            base.OnDeactivate(close);
        }
    }
}