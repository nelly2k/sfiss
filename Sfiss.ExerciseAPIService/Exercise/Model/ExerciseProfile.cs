using AutoMapper;

namespace Sfiss.ExerciseAPIService.Exercise.Model
{
    public class ExerciseProfile:Profile
    {
        public ExerciseProfile()
        {
            CreateMap<ExerciseDto, Exercise>()
                .ForMember(s => s.Complexity, o => o.MapFrom(d => d.Complexity.ToString()))
                .ForMember(s => s.ExerciseType, o => o.MapFrom(d => d.ExerciseType.ToString()));

            CreateMap<ExerciseDto, ExerciseBrief>();
        }
    }
}
