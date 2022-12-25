using Chainblock.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chainblock.Tests
{
    [TestFixture]
    public class ChainblockTests
    {
        private IChainblock blockChain;
        private Mock<ITransaction> fakeTransaction_One;
        private Mock<ITransaction> fakeTransaction_Two;

        [Test]
        public void Test_Add_TryAddingTransaction()
        {
            blockChain.Add(fakeTransaction_One.Object);

            Assert.AreEqual(1, blockChain.Count);
        }

        [Test]
        public void Test_ContainsValue_WorksProperly()
        {
            blockChain.Add(fakeTransaction_One.Object);

            Assert.IsTrue(blockChain.Contains(fakeTransaction_One.Object));
        }
        
        [Test]
        public void Test_ContainsID_WorksProperly()
        {
            blockChain.Add(fakeTransaction_One.Object);

            Assert.IsTrue(blockChain.Contains(1));
        }

        [Test]
        public void Test_ChangeTransactionStatus_ChangesItsStatus()
        {
            blockChain.Add(fakeTransaction_One.Object);
            blockChain.ChangeTransactionStatus(1, TransactionStatus.Failed);
            var bChResult = blockChain.GetById(1);
            Assert.AreEqual(TransactionStatus.Failed, bChResult.Status);
        }

        [Test]
        public void Test_RemoveTransactionById_WorksProperly()
        {
            blockChain.Add(fakeTransaction_One.Object);
            blockChain.Add(fakeTransaction_Two.Object);

            blockChain.RemoveTransactionById(2);

            Assert.AreEqual(1, blockChain.Count);
            Assert.IsTrue(blockChain.Contains(2) == false);
        }



        [SetUp]
        public void InitialData()
        {
            blockChain = new ChainBlock();
            fakeTransaction_One = new Mock<ITransaction>();
            fakeTransaction_Two = new Mock<ITransaction>();

            fakeTransaction_One.Setup(ft => ft.Id).Returns(1);
            fakeTransaction_One.SetupSet(ft => ft.Amount = 100);
            fakeTransaction_One.SetupSet(ft => ft.Status = TransactionStatus.Successfull);
            fakeTransaction_One.Setup(ft => ft.From).Returns("Daniel");
            fakeTransaction_One.Setup(ft => ft.To).Returns("Robert");
            
            fakeTransaction_Two.Setup(ft => ft.Id).Returns(2);
            fakeTransaction_Two.SetupSet(ft => ft.Amount = 100);
            fakeTransaction_Two.SetupSet(ft => ft.Status = TransactionStatus.Successfull);
            fakeTransaction_Two.Setup(ft => ft.From).Returns("Robert");
            fakeTransaction_Two.Setup(ft => ft.To).Returns("Daniel");

            
        }
    }
}
