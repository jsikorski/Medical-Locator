using MedicalLocator.WebFront.Infrastructure;
using MedicalLocator.WebFront.Models.CommandsData;
using MedicalLocator.WebFront.ViewModels;

namespace MedicalLocator.WebFront.Models
{
    [SingleInstance]
    public class CurrentContext
    {
        public SearchData LastSearchData { get; private set; }

        public CurrentContext()
        {
            LastSearchData = null;
        }

        public void UpdateLastSearchData(SearchData newSearchData)
        {
            LastSearchData = newSearchData;
        }
    }
}