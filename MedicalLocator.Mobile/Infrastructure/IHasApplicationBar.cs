using Microsoft.Phone.Shell;

namespace MedicalLocator.Mobile.Infrastructure
{
    public interface IHasApplicationBar
    {
        IApplicationBar ApplicationBar { get; }
    }
}