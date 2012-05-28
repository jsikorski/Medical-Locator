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
        private const string LoginRegex = @"^[a-zA-Z][a-zA-Z0-9]*$";
        private const string PasswordRegex = @"^[a-zA-Z][a-zA-Z0-9\!@#$%^&*-_=+]*$";

        [DisplayName("Login")]
        [Required]
        [StringLength(16, MinimumLength = 3, ErrorMessage = "Login must be between 3 and 16 characters long.")]
        [RegularExpression(LoginRegex, ErrorMessage = "Special characters are not allowed in login.")]
        public string Login { get; set; }

        [DisplayName("Password")]
        [Required]
        [StringLength(16, MinimumLength = 4, ErrorMessage = "Password must be between 4 and 16 characters long.")]
        [RegularExpression(PasswordRegex, ErrorMessage = "Special characters are not allowed in password.")]
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