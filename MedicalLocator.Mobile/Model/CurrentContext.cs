using System.Collections.Generic;
using MedicalLocator.Mobile.Features;
using MedicalLocator.Mobile.Infrastructure;
using System.Linq;

namespace MedicalLocator.Mobile.Model
{
    [SingleInstance]
    public class CurrentContext
    {
        public bool AreLocationServicesAllowed { get; set; }

        public IEnumerable<MedicalTypeViewModel> LastSearchedMedicalTypes { get; set; }
        public CenterType LastCenterType { get; set; }
        public int LastRange { get; set; }
        public string LastAddress { get; set; }
        public double LastLongitude { get; set; }
        public double LastLatitude { get; set; }

        public string CurrentUserLogin { get; set; }
        public string CurrentUserPassword { get; set; }
        public bool IsAnonymousUser { get; set; }

        public IEnumerable<MedicalType> GetSelectedMedicalTypes()
        {
            return LastSearchedMedicalTypes
                .Where(typeVm => typeVm.IsSelected).Select(typeVm => typeVm.MedicalType).ToList();
        }
    }
}