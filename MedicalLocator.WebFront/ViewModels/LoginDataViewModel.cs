using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using MedicalLocator.WebFront.DatabaseConnectionReference;
using MedicalLocator.WebFront.Models;
using MedicalLocator.WebFront.Models.CommandsData;
using MedicalLocator.WebFront.Validation;

namespace MedicalLocator.WebFront.ViewModels
{
    public class LoginDataViewModel
    {
        public LoginData LoginData { get; set; }
        public RegisterData RegisterData { get; set; }

        public LoginDataViewModel()
        {
            LoginData = new LoginData();
            RegisterData = new RegisterData();
        }

        // Constructor public for ASP binding
       // public SearchDataViewModel()
      //  {
      //  }

      //  private static bool WasMedicalTypeSelected(MedicalType medicalType, SearchData lastSearchData)
      //  {
      //      return lastSearchData.SearchedMedicalTypes.Contains(medicalType);
      //  }
    }
}