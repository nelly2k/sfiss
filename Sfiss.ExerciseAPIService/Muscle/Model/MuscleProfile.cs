using AutoMapper;

namespace Sfiss.ExerciseAPIService.Muscle
{
    public class MuscleProfile:Profile
    {
        public MuscleProfile()
        {
            CreateMap<MuscleDto, Muscle>()
                .ForMember(d => d.Area, o => o.MapFrom(s => s.Area.ToString()));
        }
    }
}