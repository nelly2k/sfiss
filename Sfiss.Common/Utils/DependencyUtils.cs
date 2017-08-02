using System.Linq;
using System.Reflection;
using Microsoft.Practices.Unity;
using Sfiss.Common.Contract;

namespace Sfiss.Common.Utils
{
    public static class DependencyUtils
    {
        public static void RegisterServices(IUnityContainer container, Assembly  assembley = null)
        {
            var serviceType = typeof(IService);
            if (assembley == null)
            {
                assembley = Assembly.GetExecutingAssembly();
            }
            var allTypes = assembley
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
