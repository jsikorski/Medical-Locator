using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MedicalLocator.WebFront.Infrastructure;
using MedicalLocator.WebFront.Validation;

namespace MedicalLocator.WebFront.Models.CommandsData
{
    public class LogoutData : ICommandData
    {
        // chyba ta klasa po prostu bêdzie musia³a istnieæ...
        public bool? Really { get; set; }
    }
}