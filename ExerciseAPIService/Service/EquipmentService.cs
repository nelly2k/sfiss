using ExerciseAPIService.Model;
using Sfiss.Common.Database;
using Sfiss.Common.Model;

namespace ExerciseAPIService.Service
{
    public interface IEquipmentService
    {
        PaginationResult<Equipment> Search(SearchEquipmentRequest request);
    }

    public class EquipmentService : IEquipmentService
    {
        private readonly IRepositoryService _repoService;

        public EquipmentService(IRepositoryService repoService)
        {
            _repoService = repoService;
        }

        public PaginationResult<Equipment> Search(SearchEquipmentRequest request)
        {
            return _repoService.Search<Equipment>(request, "Muscle", "Title", (sb, parameters) =>
            {
                sb.AppendNotNull(request.Title, " Title LIKE CONCAT('%',@Title,'%') OR  OtherTitle LIKE CONCAT('%',@Title,'%') ", parameters, nameof(request.Title), request.Title)
                    .AppendNotNull(request.ExerciseId, " EXISTS(select * from [ExerciseEquipment] em where em.EquipmentId = e.Id AND em.ExerciseId = @ExerciseId", parameters, nameof(request.ExerciseId), request.ExerciseId);
            });
        }
    }
}