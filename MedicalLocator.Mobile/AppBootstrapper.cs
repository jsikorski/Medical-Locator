using System.Linq;
using System.Reflection;
using Autofac;
using MedicalLocator.Mobile.Commands;

namespace MedicalLocator.Mobile
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Controls;
    using Microsoft.Phone.Controls;
    using Caliburn.Micro;

    public class AppBootstrapper : PhoneBootstrapper
    {
        private IContainer _container;

        protected override void Configure()
        {
            _container = CreateContainer();
            AddCustomConventions();
        }

        protected override object GetInstance(Type serviceType, string key)
        {
            return _container.Resolve(serviceType);
        }

        protected override IEnumerable<object> GetAllInstances(Type serviceType)
        {
            return _container.Resolve(serviceType.MakeArrayType()) as IEnumerable<object>;
        }

        static void AddCustomConventions()
        {
            ConventionManager.AddElementConvention<Pivot>(Pivot.ItemsSourceProperty, "SelectedItem", "SelectionChanged").ApplyBinding =
                (viewModelType, path, property, element, convention) =>
                {
                    if (ConventionManager
                        .GetElementConvention(typeof(ItemsControl))
                        .ApplyBinding(viewModelType, path, property, element, convention))
                    {
                        ConventionManager
                            .ConfigureSelectedItem(element, Pivot.SelectedItemProperty, viewModelType, path);
                        ConventionManager
                            .ApplyHeaderTemplate(element, Pivot.HeaderTemplateProperty, null, viewModelType);
                        return true;
                    }

                    return false;
                };

            ConventionManager.AddElementConvention<Panorama>(Panorama.ItemsSourceProperty, "SelectedItem", "SelectionChanged").ApplyBinding =
                (viewModelType, path, property, element, convention) =>
                {
                    if (ConventionManager
                        .GetElementConvention(typeof(ItemsControl))
                        .ApplyBinding(viewModelType, path, property, element, convention))
                    {
                        ConventionManager
                            .ConfigureSelectedItem(element, Panorama.SelectedItemProperty, viewModelType, path);
                        ConventionManager
                            .ApplyHeaderTemplate(element, Panorama.HeaderTemplateProperty, null, viewModelType);
                        return true;
                    }

                    return false;
                };
        }

        private IContainer CreateContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(type => !type.Name.EndsWith("ViewModel")).AsSelf().AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(type => type.Name.EndsWith("ViewModel")).SingleInstance();

            ////  register phone services
            //var caliburnAssembly = AssemblySource.Instance.Union(new[] { typeof(IStorageMechanism).Assembly }).ToArray();
            ////  register IStorageMechanism implementors
            //builder.RegisterAssemblyTypes(caliburnAssembly)
            //  .Where(type => typeof(IStorageMechanism).IsAssignableFrom(type)
            //                 && !type.IsAbstract
            //                 && !type.IsInterface)
            //  .As<IStorageMechanism>()
            //  .SingleInstance();

            ////  register IStorageHandler implementors
            //builder.RegisterAssemblyTypes(caliburnAssembly)
            //  .Where(type => typeof(IStorageHandler).IsAssignableFrom(type)
            //                 && !type.IsAbstract
            //                 && !type.IsInterface)
            //  .As<IStorageHandler>()
            //  .SingleInstance();

            // The constructor of these services must be called
            // to attach to the framework properly.
            var phoneService = new PhoneApplicationServiceAdapter(RootFrame);
            var navigationService = new FrameAdapter(RootFrame);

            builder.RegisterInstance<INavigationService>(navigationService).SingleInstance();
            builder.RegisterInstance<IPhoneService>(phoneService).SingleInstance();
            builder.Register<IEventAggregator>(c => new EventAggregator()).SingleInstance();
            builder.Register<IWindowManager>(c => new WindowManager()).SingleInstance();
            builder.Register<IVibrateController>(c => new SystemVibrateController()).SingleInstance();
            builder.Register<ISoundEffectPlayer>(c => new XnaSoundEffectPlayer()).SingleInstance();
            builder.RegisterType<StorageCoordinator>().AsSelf().SingleInstance();
            builder.RegisterType<TaskController>().AsSelf().SingleInstance();

            builder.Register(c => _container).SingleInstance();

            return builder.Build();
        }
    }
}

