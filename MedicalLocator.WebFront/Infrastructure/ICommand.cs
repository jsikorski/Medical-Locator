using System.Web.Mvc;

namespace MedicalLocator.WebFront.Infrastructure
{
    public interface ICommand<in T> where T : ICommandData
    {
        object Result { get; }
        void Execute(T commandData);
    }
}