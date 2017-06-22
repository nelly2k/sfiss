using System.Collections.Generic;
using Sfiss.Common.Model;

namespace ExerciseAPIService.Model
{
    public class SearchExerciseResponse: PaginationResult
    {
        public IEnumerable<ExerciseBrief> Data { get; set; }
    }
}