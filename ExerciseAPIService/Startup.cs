using System.Runtime.Remoting.Contexts;
using System.Web.Http;
using ExerciseAPIService.App;
using Microsoft.Practices.Unity;
using Owin;

namespace ExerciseAPIService
{
    public static class Startup
    {
        
        // This code configures Web API. The Startup class is specified as a type
        // parameter in the WebApp.Start method.
        public static void ConfigureApp(IAppBuilder appBuilder, ExerciseConfiguration exerciseConfig)
        {
            // Configure Web API for self-host. 
            HttpConfiguration config = new HttpConfiguration();
            DependecyProvider.Config(config, exerciseConfig);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            appBuilder.UseWebApi(config);
        }

        
    }
}
