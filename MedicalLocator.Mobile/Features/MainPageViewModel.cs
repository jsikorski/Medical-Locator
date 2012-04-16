using Autofac;
using Caliburn.Micro;
using MedicalLocator.Mobile.BingMaps;
using MedicalLocator.Mobile.Commands;
using MedicalLocator.Mobile.Infrastructure;
using Microsoft.Phone.Controls.Maps;
using Microsoft.Phone.Shell;

namespace MedicalLocator.Mobile.Features
{
    [SingleInstance]
    public class MainPageViewModel : Screen, IBusyScope, IBingMapHandler, IHasApplicationBar
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly IContainer _container;
        private Map _bingMap;

        public MainPageViewModel(IEventAggregator eventAggregator, IContainer container)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);

            _container = container;
            BingMapPushpins = new BindableCollection<PushpinViewModel>();
        }

        public void FindNearby()
        {
            var command = _container.Resolve<FindNearby>();
            CommandInvoker.Invoke(command);
        }

        public void SearchSearchPage()
        {
            ExecuteCommand<OpenSearchPage>();
        }

        public void OpenSettingsPage()
        {
            ExecuteCommand<OpenSettingsPage>();
        }

        public void OpenAboutPage()
        {
            ExecuteCommand<ShowAboutPage>();
        }

        private void ExecuteCommand<T>() where T : ICommand
        {
            var command = _container.Resolve<T>();
            CommandInvoker.Execute(command);
        }

        protected override void OnDeactivate(bool close)
        {
            var command = _container.Resolve<StopLocationServices>();
            CommandInvoker.Invoke(command);
            base.OnDeactivate(close);
        }

        protected override void OnViewAttached(object view, object context)
        {
            var mainPage = (MainPage) view;
            ApplicationBar = mainPage.ApplicationBar;
            _bingMap = mainPage.BingMap;
            base.OnViewAttached(view, context);
        }

        #region Implementation of IBusyScope

        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                NotifyOfPropertyChange(() => IsBusy);
            }
        }

        #endregion

        #region Implementation of IBingMapHandler

        public BindableCollection<PushpinViewModel> BingMapPushpins { get; private set; }

        public void UpdateBingMapView()
        {
            _bingMap.UpdateView(BingMapPushpins);
        }

        #endregion

        #region Implementation of IHasApplicationBar

        public IApplicationBar ApplicationBar { get; private set; }

        #endregion
    }
}

