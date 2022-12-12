namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class ArenaTests
    {
        private Warrior warrior;
        private Warrior warrior2;
        [SetUp]
        public void Setup()
        {
            warrior = new Warrior("Jimmy", 100, 100);
            warrior2 = new Warrior("Carl", 100, 100);
        }

        [Test]
        public void Test_Contructor()
        {
            var arena = new Arena();
            var warriors = new List<Warrior>();
            Assert.AreEqual(warriors, arena.Warriors);
        }

        [Test]
        public void Test_Enroll_ValidationOf_AlreadyExistingWarrior()
        {
            var arena = new Arena();
            arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(
                ()=> arena.Enroll(warrior));
        }

        [TestCaseSource("PushAttacker")]
        [TestCaseSource("PushDefender")]
        public void Test_Fight_ExceptionFor_UnexistantWarrior(Warrior warrior)
        {
            var arena = new Arena();
            arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(
                ()=> arena.Fight("Jimmy", "Carl"));
        }

        [Test]
        public void Test_Properties()
        {
            var arena = new Arena();
            arena.Enroll(warrior);
            IReadOnlyCollection<Warrior> expectedOutput = new Warrior[] { warrior };

            Assert.AreEqual(expectedOutput, arena.Warriors);
        }

        [Test]
        public void Fight_Correctly()
        {
            Arena arena = new Arena();
            arena.Enroll(warrior);
            arena.Enroll(warrior2);

            arena.Fight("Jimmy", "Carl");

            var expectedPeshoHp = 0;
            var actual = warrior2.HP;
            Assert.AreEqual(expectedPeshoHp, actual);
        }

        private static IEnumerable<TestCaseData> PushAttacker()
        {
            var warrior = new Warrior("Jimmy", 100, 110);
            yield return new TestCaseData(warrior);
        }
        
        private static IEnumerable<TestCaseData> PushDefender()
        {
            var warrior = new Warrior("Carl", 100, 110);
            yield return new TestCaseData(warrior);
        }

    }
}
