using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Cache;
using System.Web;
using System.Web.Mvc;

namespace MedicalLocator.WebFront.Infrastructure
{
    public class CommandsController : Controller
    {
        public ICommandsDataProcessor CommandsDataProcessor { get; set; }
        
        protected object LastCommandResult { get; private set; }

        private bool _isNotificationSet;
        private NotificationType _notificationType;
        private string _notificationMessage;

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (_isNotificationSet)
            {
                HttpResponseBase response = filterContext.HttpContext.Response;
                response.AddHeader("X-Notification-Type", _notificationType.ToString());
                response.AddHeader("X-Notification-Message", _notificationMessage);
            }

            base.OnActionExecuted(filterContext);
        }

        protected ActionResult ProcessCommandData(ICommandData commandData,
            Func<ActionResult> onSuccess, Func<ActionResult> onFailure = null)
        {
            CommandDataProcessResult processResult = CommandsDataProcessor.ProcessCommandData(commandData);

            if (processResult is CommandDataProcessSuccess)
            {
                var processSuccess = (CommandDataProcessSuccess)processResult;
                LastCommandResult = processSuccess.CommandResult;
                return onSuccess();
            }
            else
            {
                var processFailure = (CommandDataProcessFailure)processResult;
                LastCommandResult = null;
                return InvokeFailureAction(processFailure.CommandExceptionModel, onFailure);
            }
        }

        protected void SetNotification(NotificationType notificationType, string notificationMessage)
        {
            _notificationType = notificationType;
            _notificationMessage = notificationMessage;
            _isNotificationSet = true;
        }

        protected string RenderPartialViewToString(string viewName, object model)
        {
            if (string.IsNullOrEmpty(viewName))
                viewName = ControllerContext.RouteData.GetRequiredString("action");

            ViewData.Model = model;

            using (var sw = new StringWriter())
            {
                ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                var viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);

                return sw.GetStringBuilder().ToString();
            }
        }

        private ActionResult InvokeFailureAction(ExceptionModel exceptionModel, Func<ActionResult> customOnFailure)
        {
            if (customOnFailure != null)
            {
                return customOnFailure();
            }

            NotificationType notificationType = exceptionModel.NotificationType;
            string notificationMessage = exceptionModel.NotificationMessage;
            SetNotification(notificationType, notificationMessage);

            if (HttpContext.Request.IsAjaxRequest())
            {
                return Json("Failure", JsonRequestBehavior.AllowGet);
            }

            return new EmptyResult();
        }
    }
}