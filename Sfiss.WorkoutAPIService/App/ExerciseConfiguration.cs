using Sfiss.Common.Contract;

namespace Sfiss.WorkoutAPIService.App
{
    public interface IWorkouteConfiguration:IConnectionStringConfiguration
    {
    }

    public class WorkoutConfiguration : IWorkouteConfiguration
    {
        public string ConnectionString { get; set; }
    }
}