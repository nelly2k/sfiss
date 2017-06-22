using ExerciseAPIService.Model;
using ExerciseAPIService.Service;
using NSubstitute;
using NUnit.Framework;

namespace Sfiss.ExerciseApiService.Test
{
    public class MuscleServieTests
    {

        [Test]
        public void NoParameters()
        {
            var dbService = Substitute.For<IDbService>();
            var repoService = new RepositoryService(dbService);
            
            var muscleService = new MuscleServise(repoService);

            muscleService.Search(new SearchMuscleRequest() {IsPaginated = false});


        }
    }
}
