using Sfiss.Common.Model;

namespace Sfiss.ExerciseAPIService.Muscle
{
    public class Muscle : Entity
    {
        public Area Area { get; set; }
    }

    public class MuscleDto : Entity
    {
        public string Area { get; set; }
    }
}
