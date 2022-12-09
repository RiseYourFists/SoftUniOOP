namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;



    [TestFixture]
    public class ExtendedDatabaseTests
    {

        // Capacity tests
        [TestCaseSource(typeof(TestData), "GetData", new object[] { 1 })]// Test 1
        public void Test_ConstructorArgs_OutOfRange(Person[] people)
            => Assert.Throws<ArgumentException>(() => new Database(people));

        [TestCaseSource(typeof(TestData), "GetData", new object[] { 2 })]// Test 2
        public void Test_Capacity_OutOfRange(Person[] people)
        {
            var database = new Database(people);
            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(1000, "Mary")));
        }

        // Add operation tests
        [TestCaseSource(typeof(TestData), "GetData", new object[] { 3 })]// Test 3
        public void Test_AddOperation_AlreadyHasExisting_PersonName(Person[] people)
        {
            var database = new Database(people);
            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(1000, "1 Bob")));
        }

        [TestCaseSource(typeof(TestData), "GetData", new object[] { 4 })]// Test 4
        public void Test_AddOperation_AlreadyHasExisting_PersonID(Person[] people)
        {
            var database = new Database(people);
            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(1, "1000 Bob")));
        }

        // Remove operation tests
        [TestCaseSource(typeof(TestData), "GetData", new object[] { 5 })]// Test 5
        public void Test_RemoveOperation_ShouldRemove_LastElement_InCollection(Person[] people, string expectedOutput, int expectedCount)
        {
            var database = new Database(people);
            database.Remove();
            Assert.AreEqual(expectedCount, database.Count);
            Assert.AreEqual(expectedOutput, database.FindByUsername(expectedOutput).UserName);
        }

        [TestCaseSource(typeof(TestData), "GetData", new object[] { 6 })]// Test 6
        public void Test_RemoveOperation_OnEmptyCollection(Person[] people)
        {
            var database = new Database(people);
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        // Find by name tests
        [TestCaseSource(typeof(TestData), "GetData", new object[] { 7 })]// Test 7
        public void Test_FindByName_ArgsAreNull(Person[] people)
        {
            var database = new Database(people);
            Assert.Throws<ArgumentNullException>(() => database.FindByUsername(null));
        }

        [TestCaseSource(typeof(TestData), "GetData", new object[] { 8 })]// Test 8
        public void Test_FindByName_NotExistantInDB(Person[] people)
        {
            var database = new Database(people);
            Assert.Throws<InvalidOperationException>(() => database.FindByUsername("Dean"));
        }

        [TestCaseSource(typeof(TestData), "GetData", new object[] { 9 })]// Test 9
        public void Test_FindByName_CaseSensitiveArgs(Person[] people)
        {
            var database = new Database(people);
            var lowerCase = database.FindById(1).UserName.ToLower();
            bool isCaseSensitive = lowerCase == database.FindById(1).UserName;
            Assert.IsTrue(!isCaseSensitive);
        }

        // Find by ID tests
        [TestCaseSource(typeof(TestData), "GetData", new object[] { 10 })]// Test 10
        public void Test_FindByID_NotExistantInDB(Person[] people)
        {
            var database = new Database(people);
            Assert.Throws<InvalidOperationException>(() => database.FindById(100));
        }

        [TestCaseSource(typeof(TestData), "GetData", new object[] { 11 })]// Test 11
        public void Test_FindByID_InvalidNegativeID(Person[] people)
        {
            var database = new Database(people);
            Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(-1));
        }

        private class TestData
        {
            private static IEnumerable<TestCaseData> GetData(int testNumber)
            {
                TestCaseData data = null;
                switch (testNumber)
                {
                    case 1:
                        data = new TestCaseData(new[] { GeneratePeople(CSize.OutOfRange) });
                        break;
                    case 2:
                        data = new TestCaseData(new[] { GeneratePeople(CSize.Full) });
                        break;
                    case 3:
                        data = new TestCaseData(new[] { GeneratePeople(CSize.HasOne) });
                        break;
                    case 4:
                        data = new TestCaseData(new[] { GeneratePeople(CSize.HasOne) });
                        break;
                    case 5:
                        data = new TestCaseData(GeneratePeople(CSize.Full), "15 Bob", 15);
                        break;
                    case 6:
                        data = new TestCaseData(new[] { GeneratePeople(CSize.Empty) });
                        break;
                    case 7:
                        data = new TestCaseData(new[] { GeneratePeople(CSize.HasOne) });
                        break;
                    case 8:
                        data = new TestCaseData(new[] { GeneratePeople(CSize.HasOne) });
                        break;
                    case 9:
                        data = new TestCaseData(new[] { GeneratePeople(CSize.HasOne) });
                        break;
                    case 10:
                        data = new TestCaseData(new[] { GeneratePeople(CSize.HasOne) });
                        break;
                    case 11:
                        data = new TestCaseData(new[] { GeneratePeople(CSize.HasOne) });
                        break;
                }
                yield return data;
            }

            enum CSize
            {
                Empty = 0,
                HasOne = 1,
                Full = 16,
                OutOfRange = 17
            }
            private static Person[] GeneratePeople(CSize size)
            {
                var people = new Person[(int)size];

                for (int i = 0; i < (int)size; i++)
                {
                    var id = i + 1;
                    people[i] = new Person(id, id + " Bob");
                }

                return people;
            }
        }

    }
}