﻿using System;
using System.Threading;
using System.Windows.Navigation;
using Caliburn.Micro;
using MedicalLocator.Mobile.Features;
using MedicalLocator.Mobile.Infrastructure;
using MedicalLocator.Mobile.Model;

namespace MedicalLocator.Mobile.Commands
{
    public class Login : ICommand
    {
        private readonly CurrentContext _currentContext;
        private string _name;
        private string _pass;
        public Login(CurrentContext currentContext)
        {
            _currentContext = currentContext;
            _name = "";
            _pass = "";
        }

        public void LoginByNameAndPass(string name, string pass)
        {
            _name = name;
            _pass = pass;
        }

        public void LoginAnonymously()
        {
            _name = "";
            _pass = "";
        }

        public void Execute()
        {
            var client = new DatabaseConnectionReference.DatabaseConnectionServiceClient();
            var loginResponse = client.Login(_name, _pass);
            if (loginResponse.IsValid)
            {
                _currentContext.LoggedInUser = loginResponse.Name;
            }
            else
            {
                _currentContext.LoggedInUser = "Error user";
            }
        }
    }
}
