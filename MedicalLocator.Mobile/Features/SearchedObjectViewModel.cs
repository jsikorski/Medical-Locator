using MedicalLocator.Mobile.Model;
using MedicalLocator.Mobile.DatabaseConnectionReference;
using System.Linq;

namespace MedicalLocator.Mobile.Features
{
    public class SearchedObjectViewModel
    {
        private bool _isSelected;
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
            }
        }

        public MedicalType MedicalType { get; set; }

        public static SearchedObjectViewModel CreateUsingContext(MedicalType medicalType, CurrentContext currentContext)
        {
            return new SearchedObjectViewModel
                       {
                           MedicalType = medicalType,
                           IsSelected = currentContext.LoggedInUser.LastSearch.SearchedObjects.Contains(medicalType)
                       };
        }
    }
}