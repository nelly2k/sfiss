namespace ExerciseAPIService.App
{
    public interface IExerciseConfiguration
    {
        string ConnectionString { get; }
    }

    public class ExerciseConfiguration : IExerciseConfiguration
    {
      public string ConnectionString { get; set; }
    }
}