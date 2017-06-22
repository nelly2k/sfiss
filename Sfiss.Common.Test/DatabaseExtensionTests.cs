using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using NUnit.Framework;
using Sfiss.Common.Database;

namespace Sfiss.Common.Test
{
    public class DatabaseExtensionTests
    {
        private const string SOME_STRING = "Some String!";
        [Test]
        public void And_Empty()
        {
            Assert.That(new StringBuilder().And().ToString(), Is.Empty);
        }

        [Test]
        public void AndNot_Empty()
        {
            Assert.That(new StringBuilder("a").And().ToString(), Is.EqualTo("a AND "));
        }

        [Test]
        public void AppendNotNull_Null_NotAdded()
        {
            Assert.That(new StringBuilder().AppendNotNull(null, SOME_STRING, null).ToString(), Is.Empty);
        }

        [Test]
        public void AppendNotNull_NotNull_Added()
        {
            Assert.That(new StringBuilder().AppendNotNull(1, SOME_STRING, null).ToString(), Is.EqualTo(SOME_STRING));
        }

        [Test]
        public void AppendNotNull_NotNull_ParamAdded()
        {
            var isInvoked = false;
            new StringBuilder().AppendNotNull(1, SOME_STRING, () => isInvoked = true);
            
            Assert.That(isInvoked, Is.True);
        }

        [Test]
        public void AppendNotNull_BuilderNotEmty_AndAdded()
        {
            Assert.That(new StringBuilder(SOME_STRING).AppendNotNull(1, SOME_STRING, null).ToString(), Is.EqualTo($"{SOME_STRING} AND {SOME_STRING}"));
        }

        [Test]
        public void AppendInAny_SqlGenerated()
        {
            var dbParams = new ExpandoObject();
            var result = new StringBuilder(SOME_STRING).AppendInAny(ins => $"muscleId in ({ins})","myParam", new List<int> {4, 5}, dbParams);

            Assert.That(result.ToString(), Is.EqualTo($"{SOME_STRING} AND muscleId in (@myParam)"));
        }

        [Test]
        public void AppendInAny_ParamsAdded()
        {
            dynamic dbParams = new ExpandoObject();
            new StringBuilder(SOME_STRING).AppendInAny(ins => $"muscleId in ({ins})","myParam", new List<int> { 4, 5 }, (ExpandoObject)dbParams);

            Assert.That((((IDictionary<string, object>) dbParams)["myParam"] as List<int>)[0], Is.EqualTo(4));
            Assert.That((((IDictionary<string, object>) dbParams)["myParam"] as List<int>)[1], Is.EqualTo(5));
        }
    }
}
