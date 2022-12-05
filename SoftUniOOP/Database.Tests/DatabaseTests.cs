namespace Database.Tests
{
    using NUnit.Compatibility;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        [TestCase(new[] { 1, 2, 3, 4, 5 }, 5)]
        [TestCase(new int[0], 0)]
        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 }, 16)]
        public void Test_ExpectedCountOfDatabase(int[] input, object expectedOutput)
        {
            var database = new Database(input);

            Assert.AreEqual(expectedOutput, database.Count);
        }

        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 })]
        public void Test_IfDatabaseThrowsExceptionWhenOutOfRange(int[] input)
        {
            Assert.Throws<InvalidOperationException>(() => new Database(input));
        }

        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void Test_IfDatabaseThrowsExceptionWhenAddingToFullCollection(int[] input)
        {
            var database = new Database(input);

            Assert.Throws<InvalidOperationException>(() => database.Add(1));
        }

        [Test]
        public void Test_IfDatabaseStoresValueOnNextFreeCell()
        {
            var database = new Database();

            database.Add(1);

            Assert.IsTrue(database.Count == 1);
        }

        [TestCase(new[] { 1, 2, 3 })]
        [TestCase(new[] { 1, 2, 3, 4, 5, 6 })]
        public void Test_IfDatabaseRemovesLastElement(int[] input)
        {
            var expectedOutput = input[^2];
            var database = new Database(input);
            database.Remove();
            var result = database.Fetch();
            Assert.AreEqual(expectedOutput, result[^1]);
        }

        [Test]
        public void Test_IfDatabaseThrowsExceptionWhenRemovingFromEmptyCollection()
        {
            var database = new Database();

            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void Test_IfConstructorsCanReciveIntOnly()
        {
            var typeInfo = typeof(Database);

            var constructorInfo = typeInfo.GetConstructors();

            var onlyIntCtor = true;

            foreach (var constructor in constructorInfo)
            {
                foreach (var param in constructor.GetParameters())
                {
                    onlyIntCtor = param.ParameterType.Name == "Int32[]";

                    if (!onlyIntCtor) break;
                }
                if (!onlyIntCtor) break;
            }

            Assert.IsTrue(onlyIntCtor);
        }

        [Test]
        public void Test_IfFetchReturnsArray()
        {
            var typeInfo = typeof(Database);

            var methodsInfo = typeInfo.GetMethod("Fetch");

            if (methodsInfo == null)
                Assert.Fail("null method is tested");

            Assert.IsTrue(methodsInfo.ReturnType.Name == typeof(int[]).Name);
        }

    }
}
