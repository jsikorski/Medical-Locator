using System;
using System.Reflection;
using System.Web.Mvc;
using Autofac;
using MedicalLocator.WebFront.Commands;
using System.Linq;

namespace MedicalLocator.WebFront.Infrastructure
{
    public class CommandsDataProcessor : ICommandsDataProcessor
    {
        private readonly ILifetimeScope _lifetimeScope;

        public CommandsDataProcessor(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
        }

        public CommandDataProcessResult ProcessCommandData(ICommandData commandData)
        {
            var command = GetCommandByCommandData(commandData);

            try
            {
                ExecuteCommand(command, commandData);
            }
            catch (Exception exception)
            {
                ExceptionModel exceptionModel = GetExceptionModel(command, exception.InnerException);
                return new CommandDataProcessFailure(exceptionModel);
            }

            object commandResult = GetCommandResult(command);
            return new CommandDataProcessSuccess(commandResult);
        }

        private object GetCommandByCommandData(ICommandData commandData)
        {
            Type commandDataType = commandData.GetType();
            Type commandType = typeof(ICommand<>).MakeGenericType(commandDataType);
            object command = _lifetimeScope.Resolve(commandType);
            return command;
        }

        private void ExecuteCommand(object command, ICommandData commandData)
        {
            MethodInfo executeMethodInfo = command.GetType().GetMethod("Execute");
            executeMethodInfo.Invoke(command, new object[] { commandData });
        }

        private object GetCommandResult(object command)
        {
            PropertyInfo commandResultPropertyInfo = command.GetType().GetProperty("Result");
            object commandResult = commandResultPropertyInfo.GetValue(command, null);
            return commandResult;
        }

        private ExceptionModel GetExceptionModel(object command, Exception exception)
        {
            Type commandType = command.GetType();

            if (IsCommandHandlingException(commandType, exception))
            {
                MethodInfo handleExceptionMethod = commandType.GetMethod("HandleException", new[] {exception.GetType()});
                var exceptionModel = handleExceptionMethod.Invoke(command, new object[] { exception });
                return (ExceptionModel)exceptionModel;
            }

            return new ExceptionModel("Unknown error occured.", NotificationType.Error);
        }

        private bool IsCommandHandlingException(Type commandType, Exception exception)
        {
            Type[] commandInterfaces = commandType.GetInterfaces();
            Type handleExceptionInterfaceType = typeof(IHandleException<>).MakeGenericType(exception.GetType());

            return commandInterfaces.Any(interfaceType => interfaceType == handleExceptionInterfaceType);
        }
    }
}