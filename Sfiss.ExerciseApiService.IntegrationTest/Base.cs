using System.Linq;
using System.Reflection;
using Microsoft.Practices.Unity;
using NUnit.Framework;
using Sfiss.Common.Contract;
using Sfiss.ExerciseAPIService.Exercise;

namespace Sfiss.ExerciseApiService.IntegrationTest
{
    public class Base
    {
        protected UnityContainer UnityContainer;
        protected IExerciseService ExerciseService;
        public Base()
        {
            var assembly = Assembly.Load("Sfiss.ExerciseApiService");
            Assert.That(assembly, Is.Not.Null);
            UnityContainer = new UnityContainer();
            RegisterServices(UnityContainer, assembly);

            UnityContainer.RegisterInstance(typeof(IConnectionStringConfiguration), new ConnectionStringResolver());

            ExerciseService = UnityContainer.Resolve<IExerciseService>();
        }

        private static void RegisterServices(IUnityContainer container, Assembly assembly)
        {
            var serviceType = typeof(IService);
            var allTypes = assembly
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

    public class ConnectionStringResolver : IConnectionStringConfiguration
    {
        public string ConnectionString => @"Data Source=NELLISURFACE3\MSSQLSERVER2017;Initial Catalog=sfiss.exercise;Integrated Security=False;User Id=sfiss.servise;Password=Exol37an";
    }
}