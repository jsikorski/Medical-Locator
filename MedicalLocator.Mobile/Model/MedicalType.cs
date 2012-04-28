using System.Collections.Generic;
using System.Collections.ObjectModel;
using MedicalLocator.Mobile.DatabaseConnectionReference;
using MedicalLocator.Mobile.GoogleMapsInterfaceReference;

namespace MedicalLocator.Mobile.Model
{
    public enum MedicalType
    {
        Doctor,
        Dentist//,
        //Health,
        //Hospital,
        //pharmacy,
        //physiotherapist,
        //veterinary_care,
    }

    // Zakładam, że aplikacja musi posiadać enuma o identycznej strukturze jak oba WebServicy.
    // Jeżeli to założenie będzie niedopuszczalne to można dodać jakiś opis poszczególnych wartości
    // enumów (np. stringi) i wg nich odpowiednio konwertować. Ale to chyba nie ma sensu...
    public class MedicalTypeConverter
    {
        static public MedicalType FromGoogleService(MedicalTypeGoogleService medicalType)
        {
            return (MedicalType)medicalType;
        }

        static public MedicalType FromDatabaseService(MedicalTypeDatabaseService medicalType)
        {
            return (MedicalType)medicalType;
        }

        static public MedicalTypeGoogleService ToGoogleService(MedicalType medicalType)
        {
            return (MedicalTypeGoogleService)medicalType;
        }

        static public MedicalTypeDatabaseService ToDatabaseService(MedicalType medicalType)
        {
            return (MedicalTypeDatabaseService)medicalType;
        }

        // todo: zmienić to na jakieś linq, może jakieś template
        static public IEnumerable<MedicalType> FromGoogleService(IEnumerable<MedicalTypeGoogleService> collection)
        {
            var resultCollection = new ObservableCollection<MedicalType>();
            foreach (var medicalType in collection)
            {
                resultCollection.Add(FromGoogleService(medicalType));
            }
            return resultCollection;
        }

        static public IEnumerable<MedicalType> FromDatabaseService(IEnumerable<MedicalTypeDatabaseService> collection)
        {
            var resultCollection = new ObservableCollection<MedicalType>();
            foreach (var medicalType in collection)
            {
                resultCollection.Add(FromDatabaseService(medicalType));
            }
            return resultCollection;
        }

        static public IEnumerable<MedicalTypeGoogleService> ToGoogleService(IEnumerable<MedicalType> collection)
        {
            var resultCollection = new ObservableCollection<MedicalTypeGoogleService>();
            foreach (var medicalType in collection)
            {
                resultCollection.Add(ToGoogleService(medicalType));
            }
            return resultCollection;
        }

        static public IEnumerable<MedicalTypeDatabaseService> ToDatabaseService(IEnumerable<MedicalType> collection)
        {
            var resultCollection = new ObservableCollection<MedicalTypeDatabaseService>();
            foreach (var medicalType in collection)
            {
                resultCollection.Add(ToDatabaseService(medicalType));
            }
            return resultCollection;
        }
    }
}