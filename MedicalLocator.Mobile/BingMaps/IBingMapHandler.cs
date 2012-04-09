using System.Collections.ObjectModel;
using Caliburn.Micro;
using Microsoft.Phone.Controls.Maps;

namespace MedicalLocator.Mobile.BingMaps
{
    public interface IBingMapHandler
    {
        BindableCollection<PushpinViewModel> BingMapPushpins { get; }
        void UpdateBingMapView();
    }
}