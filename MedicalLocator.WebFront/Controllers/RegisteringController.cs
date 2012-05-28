using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using MedicalLocator.WebFront.Infrastructure;
using MedicalLocator.WebFront.Models;
using MedicalLocator.WebFront.Models.CommandsData;
using MedicalLocator.WebFront.Services;
using MedicalLocator.WebFront.ViewModels;

namespace MedicalLocator.WebFront.Controllers
{
    public class RegisteringController : CommandsController
    {
        public RegisteringController()
        {
        }

        public ActionResult Register(string login, string password, string passwordRetype, bool licenceAgree)
        {
            var registerDataViewModel = new LoginDataViewModel();
            registerDataViewModel.RegisterData = new RegisterData { Login = login, Password = password, PasswordRetype = passwordRetype, LicenceAgree = licenceAgree};

            if (!IsRegisterDataViewModelValid(registerDataViewModel))
            {
                SetNotification(NotificationType.Error, "Some of the input data are invalid.");
                return FailureJsonResult();
            }

            return ProcessCommandData(registerDataViewModel.RegisterData, () => Json(LastCommandResult, JsonRequestBehavior.AllowGet));
        }

        private bool IsRegisterDataViewModelValid(LoginDataViewModel loginDataViewModel)
        {
            return ModelState.IsValid && loginDataViewModel.RegisterData.IsValid();
        }
    }
}
