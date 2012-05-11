﻿using MedicalLocator.WebFront.DatabaseConnectionReference;

namespace MedicalLocator.WebFront.Models
{
    public enum CenterType
    {
        MyLocation,
        Address,
        Coordinates
    }

    public class CenterTypeConverter
    {
        public static CenterType FromDatabaseService(CenterTypeDatabaseService centerType)
        {
            return (CenterType)centerType;
        }

        public static CenterTypeDatabaseService ToDatabaseService(CenterType centerType)
        {
            return (CenterTypeDatabaseService)centerType;
        }
    }
}