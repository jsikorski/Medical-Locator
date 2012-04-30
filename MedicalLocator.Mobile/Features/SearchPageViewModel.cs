using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Windows;
using Autofac;
using Caliburn.Micro;
using MedicalLocator.Mobile.Commands;
using MedicalLocator.Mobile.DatabaseConnectionReference;
using MedicalLocator.Mobile.Infrastructure;
using MedicalLocator.Mobile.Model;
using IContainer = Autofac.IContainer;

namespace MedicalLocator.Mobile.Features
{
    [SingleInstance]
    public class SearchPageViewModel : Screen
    {
        private readonly CurrentContext _currentContext;
        private readonly IEnumsValuesProvider _enumsValuesProvider;
        private readonly IContainer _container;

        public int SearchingRange
        {
            get { return _currentContext.LastRange; }
            set { _currentContext.LastRange = value; }
        }

        public IEnumerable<CenterType> PossibleSearchingCenterTypes { get; set; }
        public int SelectedCenterTypeIndex
        {
            get { return PossibleSearchingCenterTypes.ToList().IndexOf(_currentContext.LastCenterType); }
            set { _currentContext.LastCenterType = PossibleSearchingCenterTypes.ElementAt(value); }
        }

        public string SearchedAddress
        {
            get { return _currentContext.LastAddress; }
            set { _currentContext.LastAddress = value; }
        }

        public double SearchedLatitude
        {
            get { return _currentContext.LastLatitude; }
            set { _currentContext.LastLatitude = value; }
        }

        public double SearchedLongitude
        {
            get { return _currentContext.LastLongitude; }
            set { _currentContext.LastLongitude = value; }
        }

        public IEnumerable<MedicalTypeViewModel> SearchedMedicalTypes
        {
            get { return _currentContext.LastSearchedMedicalTypes; }
        }

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
    }
}