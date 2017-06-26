using Sfiss.Common.Contract;

namespace Sfiss.ExerciseAPIService.App
{
    public interface IExerciseConfiguration:IConnectionStringConfiguration
    {
    }

    public class ExerciseConfiguration : IExerciseConfiguration
    {
        public string ConnectionString { get; set; }
    }
}