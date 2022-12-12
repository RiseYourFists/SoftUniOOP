namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class WarriorTests
    {

        [Test]
        public void Test_Warrior_Constructor()
        {
            Warrior warrior = new Warrior("Bob", 100, 100);

            var expectedName = "Bob";
            var expectedDmg = 100;
            var expectedHp = 100;

            Assert.AreEqual(expectedName, warrior.Name);
            Assert.AreEqual(expectedDmg, warrior.Damage);
            Assert.AreEqual(expectedHp, warrior.HP);
        }

        [TestCase(null, 100, 100)]
        [TestCase("", 100, 100)]
        [TestCase(" ", 100, 100)]
        public void Test_Name_ValidationFor_NullEmptyOrWhiteSpace
            (string name, int damage, int health)
        {
            Assert.Throws<ArgumentException>(
                () => new Warrior(name, damage, health));
        }

        [TestCase("Andrew", 0, 100)]
        [TestCase("Andrew", -1, 100)]
        public void Test_Damage_ValidationFor_ZeroOrNegative
            (string name, int damage, int health)
        {
            Assert.Throws<ArgumentException>(
                () => new Warrior(name, damage, health));
        }

        [TestCase("Andrew", 100, -1)]
        public void Test_HP_ValidationIf_Negative
            (string name, int damage, int health)
        {
            Assert.Throws<ArgumentException>(
                () => new Warrior(name, damage, health));
        }

        [Test]
        public void Test_Attack_Exception_IfAttackerBelow_30HP()
        {
            var attacker = new Warrior("Andrew", 100, 29);

            var victim = new Warrior("Brad", 10, 100);

            Assert.Throws<InvalidOperationException>(
                () => attacker.Attack(victim));
        }

        [Test]
        public void Test_Attack_Exception_IfVictimBelow_30HP()
        {
            var attacker = new Warrior("Brad", 100, 100);

            var victim = new Warrior("Andrew", 99, 29);

            Assert.Throws<InvalidOperationException>(
                () => attacker.Attack(victim));
        }
        
        [Test]
        public void Test_Attack_Exception_IfVictimDmg_IsHiegher_ThanAttackerHP()
        {
            var attacker = new Warrior("Brad", 100, 50);

            var victim = new Warrior("Andrew", 100, 100);

            Assert.Throws<InvalidOperationException>(
                () => attacker.Attack(victim));
        }


        [TestCaseSource("ZeroOutput")]
        [TestCaseSource("PerciseOutput")]
        public void Test_Attack_DmgOutcome(Warrior warrior, Warrior warrior2, int expectedOutput)
        {
            warrior.Attack(warrior2);
            Assert.AreEqual(expectedOutput, warrior2.HP);
        }

        private static IEnumerable<TestCaseData> ZeroOutput()
        {
            var warrior = new Warrior("Hendric", 100, 100);
            var warrior2 = new Warrior("Hendric", 99, 50);
            yield return new TestCaseData( warrior, warrior2, 0 );
        }
        
        private static IEnumerable<TestCaseData> PerciseOutput()
        {
            var warrior = new Warrior("Hendric", 70, 100);
            var warrior2 = new Warrior("Hendric", 99, 100);
            yield return new TestCaseData( warrior, warrior2, 30 );
        }
    }
}