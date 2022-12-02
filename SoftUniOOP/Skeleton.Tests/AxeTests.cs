using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        [Test]
        public void Test_If_Axe_Loses_Durability_After_Attack()
        {
            var axe = new Axe(10, 10);

            axe.Attack(new Dummy(100, 100));

            Assert.AreEqual(9, axe.DurabilityPoints, "Axe Durability doesn't change after attack.");
        }

        [Test]
        public void Test_Attacking_With_Broken_Axe()
        {
            var axe = new Axe(10, 0);

            Assert.Throws<InvalidOperationException>(() => axe.Attack(new Dummy(100, 100)));
        }
    }
}