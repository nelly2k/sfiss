using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using ExerciseAPIService.App;
using ExerciseAPIService.Model;
using Sfiss.Common.Database;
using Sfiss.Common.Model;

namespace ExerciseAPIService.Service
{
    public interface IExerciseService
    {
        PaginationResult<ExerciseBrief> Search(SearchExerciseRequest request);
        Exercise Get(int id);
    }

    public class ExerciseService : IExerciseService
    {
        private readonly IExerciseConfiguration _exerciseConfiguration;
        private readonly IRepositoryService _repositoryService;
        private readonly IMuscleServise _muscleServise;
        private readonly IEquipmentService _equipmentService;

        public ExerciseService(IExerciseConfiguration exerciseConfiguration,IRepositoryService repositoryService, IMuscleServise muscleServise, IEquipmentService equipmentService)
        {
            _exerciseConfiguration = exerciseConfiguration;
            _repositoryService = repositoryService;
            _muscleServise = muscleServise;
            _equipmentService = equipmentService;
        }
        internal IDbConnection Connection => new SqlConnection(_exerciseConfiguration.ConnectionString);

        public Exercise Get(int id)
        {
            var result= _repositoryService.Get<Exercise>(id);
            result.Muscles = _muscleServise.Search(new SearchMuscleRequest {ExerciseId = id, IsPaginated = false}).Data;
            result.Equipments = _equipmentService.Search(new SearchEquipmentRequest {ExerciseId = id, IsPaginated = false}).Data;
            return result;
        }

        public PaginationResult<ExerciseBrief> Search(SearchExerciseRequest request)
        {
            return _repositoryService.Search<ExerciseBrief>(request, "Exercise", "Title", (sb, parameters) =>
            {
                sb.AppendNotNull(request.Title, " Title LIKE CONCAT('%',@Title,'%') OR  OtherTitle LIKE CONCAT('%',@Title,'%') ", parameters, nameof(request.Title), request.Title)
                    .AppendInAny(ins => $"e.ExerciseType in ({ins})", "exerciseType", request.Types.Select(x => (int)x).ToList(), parameters)
                    .AppendInAny(ins => $"e.Complexity in ({ins})", "complexity", request.Complexity.Select(x => (int)x).ToList(), parameters)
                    .AppendInAny(ins => $"EXISTS(select * from [ExerciseMuscle] em where em.ExerciseId = e.Id AND em.MuscleId IN ({ins})", "muscle", request.Muscles.Select(x => x.Id), parameters)
                    .AppendInAny(ins => $"EXISTS(select * from [ExerciseMuscle] em where em.ExerciseId = e.Id AND em.Area IN ({ins})", "area", request.Areas.Select(x => (int)x), parameters)
                    .AppendInAny(ins => $"EXISTS(Select * from [ExerciseEquipment] ep where ep.ExerciseId = e.Id AND ep.EquipmentId IN ({ins}))", "equipment", request.Equipments.Select(x => x.Id), parameters);
            });

            //request.OrderBy = request.OrderBy ?? "Title";
            //var sbAndParams = BuildSearchParameters(request, "SELECT Id, Title FROM [Exercise] e");
            //var serachResult = new PaginationResult<ExerciseBrief>();
            //_dbService.Run(cn => serachResult.Data = cn.Query<ExerciseBrief>(sbAndParams.Key.ToString(), sbAndParams.Value));

            //var countSbAndParam = BuildSearchParameters(request, "SELECT COUNT(*) FROM [Exercise] e", false);
            //_dbService.Run(cn => serachResult.Total = cn.Query<int>(countSbAndParam.Key.ToString(), sbAndParams.Value).SingleOrDefault());
            //return serachResult;
        }

        //private KeyValuePair<StringBuilder, object> BuildSearchParameters(SearchExerciseRequest request, string sql, bool usePagination = true)
        //{
        //    dynamic parameters = new ExpandoObject();
        //    var sb = new StringBuilder()
        //        .AppendNotNull(request.Title, " Title LIKE CONCAT('%',@Title,'%') OR  OtherTitle LIKE CONCAT('%',@Title,'%') ",
        //            () => parameters.Title = request.Title)
        //        .AppendInAny(ins => $"e.ExerciseType in ({ins})", "exerciseType", request.Types.Select(x => (int)x).ToList(), (ExpandoObject)parameters)
        //        .AppendInAny(ins => $"e.Complexity in ({ins})", "complexity", request.Complexity.Select(x => (int)x).ToList(), (ExpandoObject)parameters)
        //        .AppendInAny(
        //            ins => $"EXISTS(select * from [ExerciseMuscle] em where em.ExerciseId = e.Id AND em.MuscleId IN ({ins})",
        //            "muscle", request.Muscles.Select(x => x.Id).ToList(), (ExpandoObject)parameters)
        //        .AppendInAny(
        //            ins => $"EXISTS(select * from [ExerciseMuscle] em where em.ExerciseId = e.Id AND em.Area IN ({ins})",
        //            "area", request.Areas.Select(x => (int)x).ToList(), (ExpandoObject)parameters)

        //        .AppendInAny(
        //            ins => $"EXISTS(Select * from [ExerciseEquipment] ep where ep.ExerciseId = e.Id AND ep.EquipmentId IN ({ins}))",
        //            "equipment", request.Equipments.Select(x => x.Id).ToList(), (ExpandoObject)parameters)
        //            .Where().Pagination(request, usePagination);

        //    sb.Insert(0, sql);
        //    return new KeyValuePair<StringBuilder, object>(sb, parameters);
        //}
    }
}