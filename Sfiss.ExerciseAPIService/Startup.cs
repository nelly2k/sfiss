using System.Web.Http;
using Owin;
using Sfiss.ExerciseAPIService.App;

namespace Sfiss.ExerciseAPIService
{
    public static class Startup
    {
        // This code configures Web API. The Startup class is specified as a type
        // parameter in the WebApp.Start method.
        public static void ConfigureApp(IAppBuilder appBuilder, ExerciseConfiguration exerciseConfig)
        {
            // Configure Web API for self-host. 
            var config = new HttpConfiguration();
            DependecyProvider.Config(config, exerciseConfig);
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
