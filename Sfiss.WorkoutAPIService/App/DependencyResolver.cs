using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using Microsoft.Practices.Unity;

namespace Sfiss.WorkoutAPIService.App
{
    public class DependencyResolver:IDependencyResolver
    {
        private readonly IUnityContainer _container;

        public DependencyResolver(IUnityContainer container)
        {
            _container = container;
        }
        public void Dispose()
        {
            _container.Dispose();
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return _container.Resolve(serviceType);
            }

            catch (ResolutionFailedException rex)
            {
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return _container.ResolveAll(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return null;
            }
        }

        public IDependencyScope BeginScope()
        {
            var child = _container.CreateChildContainer();
            return new DependencyResolver(child);
        }
    }
}