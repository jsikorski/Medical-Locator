using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac;
using Autofac.Builder;
using Autofac.Features.Scanning;
using Autofac.Integration.Mvc;
using MedicalLocator.WebFront.Commands;
using MedicalLocator.WebFront.Controllers;
using MedicalLocator.WebFront.Infrastructure;

namespace MedicalLocator.WebFront
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            ConfigureContainer();
        }

        private void ConfigureContainer()
        {
            var containerBuilder = new ContainerBuilder();
            RegisterControllers(containerBuilder);
            RegisterNotControllers(containerBuilder);
            IContainer container = containerBuilder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        private void RegisterControllers(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired();
        }

        private void RegisterNotControllers(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(type => type != typeof (CommandsController) &&
                               type.BaseType != typeof (Controller) &&
                               type.BaseType != typeof (CommandsController))
                .AsSelf().AsImplementedInterfaces().PropertiesAutowired();
        }
    }
}