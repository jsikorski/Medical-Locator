using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Enums;

namespace DatabaseConnectionService.Model
{
    public class MedicalLocatorUserLastSearch
    {
        public IEnumerable<MedicalType> SearchedObjects { get; set; }
        public CenterType CenterType { get; set; }
        public int Range { get; set; }
        public string Address { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }

    public class MedicalLocatorUserData
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public MedicalLocatorUserLastSearch LastSearch { get; set; }
    }
}
