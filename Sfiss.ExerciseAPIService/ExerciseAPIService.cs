using System;
using System.Collections.Generic;
using System.Fabric;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Runtime;
using Sfiss.ExerciseAPIService.App;

namespace Sfiss.ExerciseAPIService
{
    /// <summary>
    /// The FabricRuntime creates an instance of this class for each service type instance. 
    /// </summary>
    internal sealed class ExerciseAPIService : StatelessService
    {
        public ExerciseAPIService(StatelessServiceContext context)
            : base(context)
        { }

        /// <summary>
        /// Optional override to create listeners (like tcp, http) for this service instance.
        /// </summary>
        /// <returns>The collection of listeners.</returns>
        protected override IEnumerable<ServiceInstanceListener> CreateServiceInstanceListeners()
        {
            var config = new ExerciseConfiguration();
            var configurationPackage = Context.CodePackageActivationContext.GetConfigurationPackageObject("Config");
            var connectionStringParameter = configurationPackage.Settings.Sections["ExerciseDatabase"].Parameters["ExerciseDatabaseConnectionString"];
            config.ConnectionString = connectionStringParameter.Value;
            return new ServiceInstanceListener[]
            {
                new ServiceInstanceListener(serviceContext => new OwinCommunicationListener(a=>Startup.ConfigureApp(a,config), serviceContext, ServiceEventSource.Current, "ServiceEndpoint"))
            };
        }
    }
}
