﻿using System.Linq;
using System.Reflection;
using System.Web.Http;
using Microsoft.Practices.Unity;
using Sfiss.Common.Contract;

namespace Sfiss.ExerciseAPIService.App
{
    public class DependecyProvider
    {
        public static void Config(HttpConfiguration config, ExerciseConfiguration exerciseConfiguration)
        {
            IUnityContainer container = new UnityContainer();
            RegisterControllers(container);
            RegisterServices(container);
            container.RegisterInstance(typeof(IExerciseConfiguration), exerciseConfiguration);
            container.RegisterInstance(typeof(IConnectionStringConfiguration), exerciseConfiguration);
            config.DependencyResolver = new DependencyResolver(container);
        }

        private static void RegisterControllers(IUnityContainer container)
        {
            var type = typeof(ApiController);

            var types = Assembly.GetExecutingAssembly().GetTypes().Where(p => type.IsAssignableFrom(type));

            foreach (var type1 in types)
            {
                container.RegisterType(type1);
            }
        }

        private static void RegisterServices(IUnityContainer container)
        {
            var serviceType = typeof(IService);
            var allTypes = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(x => serviceType.IsAssignableFrom(x))
                .ToList();

            var interfaces = allTypes.Where(x => x.IsInterface);

            foreach (var interfaceToRegister in interfaces)
            {
                var typeToRegister = allTypes.FirstOrDefault(x => interfaceToRegister.IsAssignableFrom(x) && x.IsClass);

                if (typeToRegister == null)
                {
                    continue;
                }

                container.RegisterType(interfaceToRegister, typeToRegister);
            }
        }
    }
}