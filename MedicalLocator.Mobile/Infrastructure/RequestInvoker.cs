using System;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Threading;
using MedicalLocator.Mobile.Commands;
using MedicalLocator.Mobile.ServicesReferences;

namespace MedicalLocator.Mobile.Infrastructure
{
    public static class RequestInvoker
    {
        public static void InvokeSync<T>(Expression<Action> request)
        {
            var syncProvider = new ManualResetEvent(false);
            
            var call = (MethodCallExpression) request.Body;
            string requestMethodName = call.Method.Name;
            string requestMethodOriginalName = call.Method.Name.Replace("Async", string.Empty);
            string completedEventHandlerName = requestMethodOriginalName + "Completed";

            //call.Method.
            //call.Method.
            Action compile = request.Compile();
            var target = (ExecutionScope)compile.Target;
            var client = ((IStrongBox)target.Globals[0]).Value;
            
            //var client = call.

            syncProvider.WaitOne();
        }
    }
}