using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MedicalLocator.WebFront.Infrastructure;
using MedicalLocator.WebFront.Validation;

namespace MedicalLocator.WebFront.Models.CommandsData
{
    public class RegisterData : ICommandData
    {
        [DisplayName("Licence Agreement")]
        [Required]
        public bool LicenceAgree { get; set; }

        [DisplayName("Login")]
        [Required]
        [MinLength(3), MaxLength(16)]
        public string Login { get; set; }

        [DisplayName("Password")]
        [Required]
        [MinLength(4), MaxLength(16)]
        public string Password { get; set; }

        [DisplayName("Retype password")]
        [Required]
        [MinLength(4), MaxLength(16)]
        public string PasswordRetype { get; set; }

        public bool IsValid()
        {
            return true; // todo: pewnie da sie lepiej niz ifem po wszystkich parametrach
        }

        public RegisterData()
        {
            LicenceAgree = false;
        }
    }
}