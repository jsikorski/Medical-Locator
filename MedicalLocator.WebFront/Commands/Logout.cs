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
    public class Logout : DatabaseCommandBase, ICommand<LogoutData>
    {
        private readonly IDatabaseManager _databaseManager;

        public object Result { get; private set; }

        public Logout(IDatabaseManager databaseManager)
        {
            _databaseManager = databaseManager;
        }

        public void Execute(LogoutData logout)
        {
            _databaseManager.TryLogout();
        }
    }
}