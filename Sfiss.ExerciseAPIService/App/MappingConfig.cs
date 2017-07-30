using Sfiss.ExerciseAPIService.Exercise.Model;
using Sfiss.ExerciseAPIService.Muscle;

namespace Sfiss.ExerciseAPIService.App
{
    public static class MappingConfig
    {
        public static void Config()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<ExerciseProfile>();
                cfg.AddProfile<MuscleProfile>();
            });
        }
    }
}
