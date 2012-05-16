using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MedicalLocator.WebFront.Infrastructure;
using MedicalLocator.WebFront.Models;
using MedicalLocator.WebFront.Models.CommandsData;
using MedicalLocator.WebFront.Validation;
using MedicalLocator.WebFront.ViewModels;

namespace MedicalLocator.WebFront.Controllers
{
    public class HomeController : CommandsController
    {
       public ActionResult Index()
        {
            return View();
        }
    }
}
