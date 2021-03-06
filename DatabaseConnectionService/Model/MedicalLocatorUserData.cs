﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatabaseConnectionService.Model
{
    public class MedicalLocatorUserLastSearch
    {
        public IEnumerable<MedicalTypeDatabaseService> SearchedObjects { get; set; }
        public CenterTypeDatabaseService CenterType { get; set; }
        public int Range { get; set; }
        public string Address { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }

    public class MedicalLocatorUserData
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public MedicalLocatorUserLastSearch LastSearch { get; set; }

        // factory method
        public static MedicalLocatorUserData CreateDefaultUser(string login, string password)
        {
            var lastSearch = new MedicalLocatorUserLastSearch
            {
                SearchedObjects = DatabaseEnumsValuesProvider.GetAllMedicalTypes(),
                CenterType = CenterTypeDatabaseService.MyLocation,
                Range = 2500,
                Address = "",
                Latitude = 0,
                Longitude = 0
            };

            var user = new MedicalLocatorUserData
            {
                UserId = Guid.NewGuid(),
                Login = login,
                Password = password,
                LastSearch = lastSearch
            };

            return user;
        }
    }
}
