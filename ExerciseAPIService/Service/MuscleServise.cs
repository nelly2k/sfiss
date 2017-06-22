using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using Dapper;
using ExerciseAPIService.Model;
using Sfiss.Common.Database;
using Sfiss.Common.Model;

namespace ExerciseAPIService.Service
{
    public interface IMuscleServise
    {
        PaginationResult<Muscle> Search(SearchMuscleRequest request);
    }

    public class MuscleServise : IMuscleServise
    {
        private readonly IRepositoryService _repoService;

        public MuscleServise(IRepositoryService repoService)
        {
            _repoService = repoService;
        }
        public PaginationResult<Muscle> Search(SearchMuscleRequest request)
        {
            return _repoService.Search<Muscle>(request, "Muscle", "Title", (sb, parameters) =>
            {
                sb.AppendNotNull(request.Title,
                        " Title LIKE CONCAT('%',@Title,'%') OR  OtherTitle LIKE CONCAT('%',@Title,'%') ", parameters,
                        nameof(request.Title), request.Title)
                    .AppendNotNull(request.ExerciseId,
                        " EXISTS(select * from [ExerciseMuscle] em where em.MuscleId = e.Id AND em.ExerciseId = @ExerciseId)",
                        parameters, nameof(request.ExerciseId), request.ExerciseId)
                    .AppendNotNull(request.Areas, " e.Area in {@Areas}", parameters, nameof(request.Areas),
                        request.Areas);
            });
        }
    }
}