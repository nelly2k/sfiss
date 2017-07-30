using System;
using System.Collections.Generic;
using System.Linq;
using FizzWare.NBuilder;
using NUnit.Framework;
using Sfiss.Common.Model;
using Sfiss.ExerciseAPIService.Equipment;
using Sfiss.ExerciseAPIService.Exercise;
using Sfiss.ExerciseAPIService.Muscle;

namespace Sfiss.ExerciseApiService.IntegrationTest
{
    public class WhenSearchForExercises:Base
    {
        [Test]
        public void NoParameters_HasResult()
        {
            Assert.That(Run().Total,Is.GreaterThan(0));
        }

        [Test]
        public void NoParameters_TotalEqualsDataSize()
        {
            var res = Run();
            Assert.That(res.Total, Is.EqualTo(res.Data.Count()));
        }

        [Test]
        public void ByTitle()
        {
            Assert.That(Run(x=>x.Title = "Leg").Data.Single().Title, Is.EqualTo("Leg Press"));
        }

        [Test]
        public void ByExerciseType()
        {
            Assert.That(Run(x=>x.Types = new List<ExerciseType>{ExerciseType.Weights }).Data.Single().Title, Is.EqualTo("Leg Press"));
        }

        [Test]
        public void ByMultipleExerciseType()
        {
            Assert.That(Run(x => x.Types = new List<ExerciseType> { ExerciseType.Weights, ExerciseType.Stretch }).Total, Is.EqualTo(2));
        }

        [Test]
        public void ByComplexity()
        {
            Assert.That(Run(x => x.Complexity = new List<Complexity> { Complexity.Intermediate }).Data.Single().Title, Is.EqualTo("Bench Press"));
        }

        [Test]
        public void ByMuscle()
        {
            Assert.That(Run(x=>x.Muscles = Builder<Muscle>.CreateListOfSize(1).All().With(m=>m.Id=2).Build()).Data.Single().Title, Is.EqualTo("Leg Press"));
        }

        [Test]
        public void ByMultipleMuscle()
        {
            Assert.That(Run(x => x.Muscles = Builder<Muscle>.CreateListOfSize(2)
            .TheFirst(1).With(m => m.Id = 2)
                .TheNext(1).With(m=>m.Id = 1)
                .Build()).Data.Single().Title, Is.EqualTo("Leg Press"));
        }

        [Test]
        public void MuscleArea()
        {
            Assert.That(Run(x=>x.Areas = new List<Area>{Area.Chest }).Data.Single().Title, Is.EqualTo("Leg Press"));
        }

        [Test]
        public void ByEquipment()
        {
            Assert.That(Run(x=>x.Equipments = Builder<Equipment>.CreateListOfSize(1).All().With(e=>e.Id = 1).Build()).Data.Single().Title, Is.EqualTo("Bench Press"));
        }

        private PaginationResult<Exercise> Run(Action<SearchExerciseRequest> requestAction = null)
        {
            var request = new SearchExerciseRequest();
            requestAction?.Invoke(request);
            return ExerciseService.Search(request);
        }
    }
}