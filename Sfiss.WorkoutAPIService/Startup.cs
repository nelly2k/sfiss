using System.Web.Http;
using Owin;
using Sfiss.WorkoutAPIService.App;

namespace Sfiss.WorkoutAPIService
{
    public static class Startup
    {
        // This code configures Web API. The Startup class is specified as a type
        // parameter in the WebApp.Start method.
        public static void ConfigureApp(IAppBuilder appBuilder, WorkoutConfiguration workoutConfig)
        {
            // Configure Web API for self-host. 
            HttpConfiguration config = new HttpConfiguration();
            DependecyProvider.Config(config, workoutConfig);
            MappingConfig.Config();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.EnableCors();
            appBuilder.UseWebApi(config);
        }
    }
}
