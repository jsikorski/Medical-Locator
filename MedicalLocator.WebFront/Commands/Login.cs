using System;
using System.Collections.Generic;
using System.Diagnostics;
using MedicalLocator.WebFront.GoogleMapsInterfaceReference;
using MedicalLocator.WebFront.Infrastructure;
using MedicalLocator.WebFront.Models;
using MedicalLocator.WebFront.Models.CommandsData;
using MedicalLocator.WebFront.Services;

namespace MedicalLocator.WebFront.Commands
{
    public class Login : LoggingCommandBase, ICommand<LoginData>
    {
        private readonly IDatabaseManager _databaseManager;

        public object Result { get; private set; }

        public Login(IDatabaseManager databaseManager)
        {
            _databaseManager = databaseManager;
        }

        public void Execute(LoginData commandData)
        {
            _databaseManager.TryLogin(commandData);
        }
    }
}