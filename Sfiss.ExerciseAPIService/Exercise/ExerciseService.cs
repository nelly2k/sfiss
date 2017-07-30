using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Sfiss.Common.Contract;
using Sfiss.Common.Database;
using Sfiss.Common.Model;
using Sfiss.ExerciseAPIService.App;
using Sfiss.ExerciseAPIService.Equipment;
using Sfiss.ExerciseAPIService.Muscle;

namespace Sfiss.ExerciseAPIService.Exercise
{
    public interface IExerciseService: IService
    {
        PaginationResult<Exercise> Search(SearchExerciseRequest request);
        Exercise Get(int id);
    }

    public class ExerciseService : IExerciseService
    {
        private readonly IExerciseConfiguration _exerciseConfiguration;
        private readonly IRepositoryService _repositoryService;
        private readonly IMuscleServise _muscleServise;
        private readonly IEquipmentService _equipmentService;

        public ExerciseService(IExerciseConfiguration exerciseConfiguration, IRepositoryService repositoryService, IMuscleServise muscleServise, IEquipmentService equipmentService)
        {
            _exerciseConfiguration = exerciseConfiguration;
            _repositoryService = repositoryService;
            _muscleServise = muscleServise;
            _equipmentService = equipmentService;
        }
        internal IDbConnection Connection => new SqlConnection(_exerciseConfiguration.ConnectionString);

        public Exercise Get(int id)
        {
            var result = _repositoryService.Get<Exercise>(id);
            result.Muscles = _muscleServise.Search(new SearchMuscleRequest { ExerciseId = id, IsPaginated = false }).Data;
            result.Equipments = _equipmentService.Search(new SearchEquipmentRequest { ExerciseId = id, IsPaginated = false }).Data;
            return result;
        }

        public PaginationResult<Exercise> Search(SearchExerciseRequest request)
        {
            return  _repositoryService.Search<ExerciseDto,Exercise>(request, "Exercise", "Title", (sb, parameters) =>
            {
                sb.AppendNotNull(request.Title, " Title LIKE CONCAT('%',@Title,'%') OR  OtherTitles LIKE CONCAT('%',@Title,'%') ", parameters, nameof(request.Title), request.Title)
                    .AppendInAny(ins => $"e.ExerciseType in {ins}", "exerciseType", request.Types.Select(x => (int)x).ToList(), parameters)
                    .AppendInAny(ins => $"e.Complexity in {ins}", "complexity", request.Complexity.Select(x => (int)x).ToList(), parameters)
                    .AppendInAny(ins => $"EXISTS(select * from [ExerciseMuscle] em where em.ExerciseId = e.Id AND em.MuscleId IN {ins})", "muscle", request.Muscles.Select(x => x.Id), parameters)
                    .AppendInAny(ins => $"EXISTS(select * from [ExerciseMuscle] em JOIN Muscle m ON em.MuscleId = m.Id where em.ExerciseId = e.Id AND m.Area IN {ins})", "area", request.Areas.Select(x => (int)x), parameters)
                    .AppendInAny(ins => $"EXISTS(Select * from [ExerciseEquipment] ep where ep.ExerciseId = e.Id AND ep.EquipmentId IN {ins})", "equipment", request.Equipments.Select(x => x.Id), parameters);
            });

            
        }
    }
}