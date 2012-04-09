using MedicalLocator.Mobile.ServicesReferences;

namespace MedicalLocator.Mobile.BingMaps
{
    public class PushpinType
    {
        public MedicalType? MedicalType { get; private set; }

        public static readonly PushpinType UserPushpin = new PushpinType { MedicalType = null };

        public static PushpinType FromMedicalType(MedicalType medicalType)
        {
            return new PushpinType { MedicalType = medicalType };
        }

        private PushpinType()
        {
        }
    }
}