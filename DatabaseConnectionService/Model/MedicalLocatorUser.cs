using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatabaseConnectionService.Model
{
    public class MedicalLocatorUserLastSearch
    {
        public string Address { get; set; }
        public bool Dentist { get; set; }
        public bool Hospital { get; set; }
    }

    public class MedicalLocatorUser
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public MedicalLocatorUserLastSearch LastSearch { get; set; }
    }
}
