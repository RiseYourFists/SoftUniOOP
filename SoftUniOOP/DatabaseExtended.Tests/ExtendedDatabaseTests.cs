namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        [TestCaseSource("CapacityTestData")]
        public void Test_Capacity_Possitive(Person[] people, int expectedOutput)
        {
            var database = new Database(people);
            Assert.AreEqual(expectedOutput, database.Count);
        }

        [TestCaseSource("OutOfRangeCollection")]
        public void Test_Capacity_Negative(Person[] people)
        {
            Assert.Throws<ArgumentException>(() => new Database(people));
        }

        [TestCaseSource("FullCollection")]
        public void Test_If_Database_ThrowsException_WhenAddingTo_FullCollection(Person[] people)
        {
            var database = new Database(people);

            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(0, "Bobster")));
        }

        private static IEnumerable<TestCaseData> CapacityTestData()
        {
            // Create different data
            var maxCapacityPeople = CreatePeople(16);
            var zeroPeople = new Person[0];

            //Add tests
            var data = new List<TestCaseData>();

            data.Add(new TestCaseData(maxCapacityPeople, 16));
            data.Add(new TestCaseData(zeroPeople, 0));

            foreach (var testCase in data)
            {
                yield return testCase;
            }
        }

        private static IEnumerable<TestCaseData> OutOfRangeCollection()
        {
            yield return new TestCaseData(new[] {CreatePeople(17)});
        }

        private static IEnumerable<TestCaseData> FullCollection()
        {
            yield return new TestCaseData(new[] { CreatePeople(16) });
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