using MedicalLocator.Mobile.Model;

namespace MedicalLocator.Mobile.Features
{
    public class MedicalTypeViewModel
    {
        public MedicalType MedicalType { get; private set; }
        public bool IsSelected { get; set; }

        public MedicalTypeViewModel(MedicalType medicalType, bool isSelected)
        {
            MedicalType = medicalType;
            IsSelected = isSelected;
        }
    }
}