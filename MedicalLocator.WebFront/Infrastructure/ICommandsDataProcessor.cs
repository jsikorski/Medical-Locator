using System;
using System.Web.Mvc;

namespace MedicalLocator.WebFront.Infrastructure
{
    public interface ICommandsDataProcessor
    {
        CommandDataProcessResult ProcessCommandData(ICommandData commandData);
    }
}