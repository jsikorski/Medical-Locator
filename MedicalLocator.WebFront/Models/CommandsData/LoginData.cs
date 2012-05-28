using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MedicalLocator.WebFront.Infrastructure;
using MedicalLocator.WebFront.Validation;

namespace MedicalLocator.WebFront.Models.CommandsData
{
    public class LoginData : ICommandData
    {
        [DisplayName("Login")]
        [Required]
        [MinLength(3), MaxLength(16)]
        public string Login { get; set; }

        [DisplayName("Password")]
        [Required]
        [MinLength(4), MaxLength(16)]
        public string Password { get; set; }

        [DisplayName("Remember me?")]
        public bool RememberMe { get; set; }

        public bool IsValid()
        {
            return true; // todo: pewnie da sie lepiej niz ifem po wszystkich parametrach
        }

        public LoginData()
        {
            RememberMe = false;
        }
    }
}