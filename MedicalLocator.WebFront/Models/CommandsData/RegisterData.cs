using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using MedicalLocator.WebFront.Infrastructure;
using MedicalLocator.WebFront.Validation;

namespace MedicalLocator.WebFront.Models.CommandsData
{
    public class RegisterData : ICommandData
    {
        private const string LoginRegex = @"^[a-zA-Z][a-zA-Z0-9]*$";
        private const string PasswordRegex = @"^[a-zA-Z0-9\!@#$%^&*-_=+]+$";

        [DisplayName("Licence Agreement")]
        [Required]
        public bool LicenceAgree { get; set; }

        [DisplayName("Login")]
        [Required]
        [StringLength(16, MinimumLength = 3, ErrorMessage = "Login must be between 3 and 16 characters long.")]
        [RegularExpression(LoginRegex, ErrorMessage = "Wrong login format.")]
        public string Login { get; set; }

        [DisplayName("Password")]
        [Required]
        [StringLength(16, MinimumLength = 4, ErrorMessage = "Password must be between 4 and 16 characters long.")]
        [RegularExpression(PasswordRegex, ErrorMessage = "Wrong password format.")]
        public string Password { get; set; }

        [DisplayName("Retype password")]
        [Required]
        [StringLength(16, MinimumLength = 4, ErrorMessage = "Password must be between 4 and 16 characters long.")]
        [RegularExpression(PasswordRegex, ErrorMessage = "Wrong password format.")]
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