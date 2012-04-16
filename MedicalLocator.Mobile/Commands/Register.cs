using System;
using System.Threading;
using System.Windows.Navigation;
using Caliburn.Micro;
using MedicalLocator.Mobile.Features;
using MedicalLocator.Mobile.Infrastructure;
using MedicalLocator.Mobile.Model;

namespace MedicalLocator.Mobile.Commands
{
    public class Register : ICommand
    {
        private readonly CurrentContext _currentContext;
        private string _name;
        private string _pass;
        public Register(CurrentContext currentContext)
        {
            _currentContext = currentContext;
        }

        public void SetNameAndPass(string name, string pass)
        {
            _name = name;
            _pass = pass;
        }

        public void Execute()
        {
            var client = new DatabaseConnectionReference.DatabaseConnectionServiceClient();
            if (client.Register(_name, _pass).IsSuccessful)
            {
                // todo: message
            }
            else
            {
                // todo: message
            }
        }
    }
}
