namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private enum CollectionType
        {
            Full,
            Empty,
            OutOfRange,
            HasOne
        }

        [TestCaseSource(
            typeof(PersonCollectionGenerator), 
            "GetCollection",
            new object[] { new CollectionType[] { CollectionType.Full, CollectionType.HasOne } })]

        public void Test_Capacity_Possitive(Person[] people)
        {
            var database = new Database(people);
            var expectedOutput = people.Length;
            Assert.AreEqual(expectedOutput, database.Count);
        }

        [TestCaseSource(
            typeof(PersonCollectionGenerator),
            "GetCollection",
            new object[] { new CollectionType[] { CollectionType.OutOfRange } })]

        public void Test_Capacity_Negative(Person[] people)
        {
            Assert.Throws<ArgumentException>(() => new Database(people));
        }

        [TestCaseSource(
            typeof(PersonCollectionGenerator),
            "GetCollection",
            new object[]{ new CollectionType[] { CollectionType.Full }})]

        public void Test_If_Database_ThrowsException_WhenAddingTo_FullCollection(Person[] people)
        {
            var database = new Database(people);

            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(0, "Bobster")));
        }

        [Test]
        public void Test_IfDatabaseStoresValueOnNextFreeCell()
        {
            var database = new Database();

            database.Add(new Person(1, "Foo"));

            Assert.IsTrue(database.Count == 1);
        }

        [TestCaseSource(
            typeof(PersonCollectionGenerator),
            "GetCollection",
            new object[] { new CollectionType[] { CollectionType.Full } })]

        public void Test_If_RemoveMethodRemoves_LastItem(Person[] people)
        {
            var database = new Database(people);

            database.Remove();

            Assert.Throws<InvalidOperationException>(() => database.FindById(15));
        }

        [Test]
        public void Test_IfDatabaseThrowsExceptionWhenRemovingFromEmptyCollection()
        {
            var database = new Database();

            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [TestCaseSource(
            typeof(PersonCollectionGenerator),
            "GetCollection",
            new object[] { new CollectionType[] { CollectionType.HasOne } })]

        public void Test_If_AddThrowsException_OnExistingData(Person[] people)
        {
            var dataBase = new Database(people);

            Assert.Throws<InvalidOperationException>(() => dataBase.Add(new Person(0, "Bobster")));
            Assert.Throws<InvalidOperationException>(() => dataBase.Add(new Person(3, "Bob0")));
        }

        [TestCaseSource(
            typeof(PersonCollectionGenerator),
            "GetCollection",
            new object[] { new CollectionType[] { CollectionType.HasOne } })]

        public void Test_FindByUser_Negative(Person[] people)
        {
            var database = new Database(people);

            Assert.Throws<ArgumentNullException>(() => database.FindByUsername(null));
            Assert.Throws<InvalidOperationException>(() => database.FindByUsername("Willy"));
        }

        [TestCaseSource(
            typeof(PersonCollectionGenerator),
            "GetCollection",
            new object[] { new CollectionType[] { CollectionType.HasOne } })]

        public void Test_FindByID_Negative(Person[] people)
        {
            var database = new Database(people);

            Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(-1));
            Assert.Throws<InvalidOperationException>(() => database.FindById(10));
        }


        [Test]
        public void Test_If_ClassHasAllMethods()
        {
            var typeInfo = typeof(Database);

            var methods = typeInfo.GetMethods((BindingFlags)60);
            var methodNames = methods.Select(m => m.Name).ToList();

            var requiredMethods = new string[] { "Add", "Remove", "FindById", "FindByUsername"};

            foreach (var item in requiredMethods)
            {
                if (!methodNames.Contains(item))
                {
                    Assert.Fail();
                }
            }

            Assert.Pass();
        }

        private class PersonCollectionGenerator
        {
            private static IEnumerable<TestCaseData> GetCollection(params CollectionType[] collectionType)
            {
                Person[] people;
                var data = new List<TestCaseData>();

                foreach (var type in collectionType)
                {
                    switch (type)
                    {
                        case CollectionType.Full:
                            people = CreatePeople(16);
                            break;
                        case CollectionType.HasOne:
                            people = CreatePeople(1);
                            break;
                        case CollectionType.OutOfRange:
                            people = CreatePeople(17);
                            break;
                        default:
                            people = new Person[0];
                            break;
                    }
                    data.Add(new TestCaseData(new[] { people }));
                }

                foreach (var testCase in data)
                {
                    yield return testCase;
                }
            }

            private static Person[] CreatePeople(int count)
            {
                var people = new Person[count];

                for (int i = 0; i < count; i++)
                {
                    people[i] = new Person(i, "Bob" + i);
                }

                return people;
            }
        }
    }
}