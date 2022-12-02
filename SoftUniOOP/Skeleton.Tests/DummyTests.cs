using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void Test_If_Dummy_Loses_Health_After_Attack()
        {
            var dummy = new Dummy(100, 100);

            dummy.TakeAttack(5);

            Assert.AreEqual(95, dummy.Health);
        }

        [Test]
        public void Test_If_Dead_Dummy_Is_Attacked_Thorws_Excception()
        {
            var deadDummy = new Dummy(0, 100);
            
            Assert.Throws<InvalidOperationException>(() => deadDummy.TakeAttack(5));
        }

        [Test]
        public void Test_If_Dead_Dummy_Drops_Exp()
        {
            var dummy = new Dummy(0, 100);
            
            var exp = dummy.GiveExperience();

            Assert.AreEqual(100, exp);
        }

        [Test]
        public void Test_If_Alive_Dummy_Can_Not_Drop_Exp()
        {
            var dummy = new Dummy(100, 100);

            Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());
        }
    }
}