﻿using System.Linq;
using System.Reflection;
using System.Web.Http;
using Microsoft.Practices.Unity;
using Sfiss.Common.Contract;
using Sfiss.Common.Utils;

namespace Sfiss.ExerciseAPIService.App
{
    public class DependecyProvider
    {
        public static void Config(HttpConfiguration config, ExerciseConfiguration exerciseConfiguration)
        {
            IUnityContainer container = new UnityContainer();
            RegisterControllers(container);
            DependencyUtils.RegisterServices(container);
            DependencyUtils.RegisterServices(container, Assembly.GetExecutingAssembly());
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
    }
}