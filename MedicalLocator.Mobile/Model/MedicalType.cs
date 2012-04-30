using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using MedicalLocator.Mobile.DatabaseConnectionReference;
using MedicalLocator.Mobile.GoogleMapsInterfaceReference;

namespace MedicalLocator.Mobile.Model
{
    public enum MedicalType
    {
        Doctor,
        Dentist,
        Health,
        Hospital,
        Pharmacy,
        Physiotherapist
    }

    // Zakładam, że aplikacja musi posiadać enuma o identycznej strukturze jak oba WebServicy.
    // Jeżeli to założenie będzie niedopuszczalne to można dodać jakiś opis poszczególnych wartości
    // enumów (np. stringi) i wg nich odpowiednio konwertować. Ale to chyba nie ma sensu...
    public class MedicalTypesConverter
    {
        public static MedicalType FromGoogleService(MedicalTypeGoogleService medicalType)
        {
            return (MedicalType)medicalType;
        }

        public static MedicalType FromDatabaseService(MedicalTypeDatabaseService medicalType)
        {
            return (MedicalType)medicalType;
        }

        public static MedicalTypeGoogleService ToGoogleService(MedicalType medicalType)
        {
            return (MedicalTypeGoogleService)medicalType;
        }

        public static MedicalTypeDatabaseService ToDatabaseService(MedicalType medicalType)
        {
            return (MedicalTypeDatabaseService)medicalType;
        }

        public static IEnumerable<MedicalType> FromGoogleService(IEnumerable<MedicalTypeGoogleService> collection)
        {
            return collection.Select(FromGoogleService);
        }

        static public IEnumerable<MedicalType> FromDatabaseService(IEnumerable<MedicalTypeDatabaseService> collection)
        {
            return collection.Select(FromDatabaseService);
        }

        static public IEnumerable<MedicalTypeGoogleService> ToGoogleService(IEnumerable<MedicalType> collection)
        {
            return collection.Select(ToGoogleService);
        }

        static public IEnumerable<MedicalTypeDatabaseService> ToDatabaseService(IEnumerable<MedicalType> collection)
        {
            return collection.Select(ToDatabaseService);
        }
    }
}