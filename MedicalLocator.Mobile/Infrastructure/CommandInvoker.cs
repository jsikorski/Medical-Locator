using System;
using System.Reflection;
using System.Threading;
using System.Windows;
using Autofac;
using System.Linq;
using Caliburn.Micro;

namespace MedicalLocator.Mobile.Infrastructure
{
    public class CommandInvoker
    {
        private const string ErrorHandlerMethodName = "HandleError";

        public static void Invoke(ICommand command)
        {
            ThreadPool.QueueUserWorkItem(s => Execute(command));
        }

        public static void Execute(ICommand command)
        {
            try
            {
                command.Execute();
            }
            catch (Exception exception)
            {
                HandleError(command, exception);
            }
        }

        private static void HandleError(ICommand command, Exception exception)
        {
            if (HasErrorHandler(command, exception))
            {
                InvokeErrorHandler(command, exception);
            }
            else
            {
                HandleUnknownError();                
            }
        }

        private static void HandleUnknownError()
        {
            Caliburn.Micro.Execute.OnUIThread(() => MessageBox.Show("Unknown error"));
        }

        private static bool HasErrorHandler(ICommand command, Exception exception)
        {
            Type handlerType = typeof(IHasErrorHandler<>).MakeGenericType(exception.GetType());
            return command.GetType().GetInterfaces().Any(t => t == handlerType);
        }

        private static void InvokeErrorHandler(ICommand command, Exception exception)
        {
            MethodInfo handlerMethod = command.GetType().GetMethod(ErrorHandlerMethodName, new[] { exception.GetType() });
            handlerMethod.Invoke(command, new object[] {exception});
        }
    }
}