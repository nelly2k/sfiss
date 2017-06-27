using System.Linq;
using NUnit.Framework;

namespace Sfiss.ExerciseApiService.IntegrationTest
{
    public class WhenGetExercise:Base
    {
        [Test]
        public void GetBody()
        {
            var result = ExerciseService.Get(2);
            Assert.That(result.Id,Is.EqualTo(2));
        }

        [Test]
        public void MusclesLoaded()
        {
            var result = ExerciseService.Get(2);
            Assert.That(result.Muscles.Count(), Is.GreaterThan(0));
        }

        [Test]
        public void EquipmentLoaded()
        {
            var result = ExerciseService.Get(2);
            Assert.That(result.Equipments.Count(), Is.GreaterThan(0));
        }

    }
}
