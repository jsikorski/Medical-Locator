﻿using System;
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
    public class LoggingController : CommandsController
    {
        public LoggingController()
        {
        }

        public ActionResult ShowLoginDialog()
        {
            var viewModel = new LoginDataViewModel();
            return PartialView("_LoginDialogPartial", viewModel);
        }

        public ActionResult Login(string login, string password, bool rememberMe)
        {
            var loginDataViewModel = new LoginDataViewModel();
            loginDataViewModel.LoginData = new LoginData {Login = login, Password = password, RememberMe = rememberMe};

            if (!IsLoginDataViewModelValid(loginDataViewModel))
            {
                SetNotification(NotificationType.Error, "Some of the input data are invalid.");
                return FailureJsonResult();
            }

            SetNotification(NotificationType.Info, "Succesfully logged in as " + login);

            return ProcessCommandData(loginDataViewModel.LoginData,
                                      () => Json(LastCommandResult, JsonRequestBehavior.AllowGet));
        }

        public ActionResult Logout()
        {
            SetNotification(NotificationType.Info, "Logged out.");
            return ProcessCommandData(new LogoutData(), () => Json(LastCommandResult, JsonRequestBehavior.AllowGet));
        }

        private bool IsLoginDataViewModelValid(LoginDataViewModel loginDataViewModel)
        {
            return ModelState.IsValid && loginDataViewModel.LoginData.IsValid();
        }
    }
}
