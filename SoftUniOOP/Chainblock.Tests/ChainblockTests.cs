using Chainblock.Contracts;
using NUnit.Framework;
using System;
using System.Linq;

namespace Chainblock.Tests
{
    [TestFixture]
    public class ChainblockTests
    {
        private IChainblock blockChain;
        private ITransaction fakeTransaction_One;
        private ITransaction fakeTransaction_Two;
        private ITransaction fakeTransaction_Three;
        private ITransaction fakeTransaction_Four;

        [Test]
        public void Test_Add_TryAddingTransaction()
        {
            blockChain.Add(fakeTransaction_One);
            Assert.AreEqual(1, blockChain.Count);
            Assert.AreEqual(fakeTransaction_One, blockChain.GetById(1));
        }

        [Test]
        public void Test_ContainsValue_WorksProperly()
        {
            blockChain.Add(fakeTransaction_One);
            Assert.IsTrue(blockChain.Contains(fakeTransaction_One));
        }

        [Test]
        public void Test_ContainsID_WorksProperly()
        {
            blockChain.Add(fakeTransaction_One);
            Assert.IsTrue(blockChain.Contains(1));
        }

        [Test]
        public void Test_ChangeTransactionStatus_ChangesItsStatus()
        {
            blockChain.Add(fakeTransaction_One);
            blockChain.ChangeTransactionStatus(1, TransactionStatus.Failed);
            var result = blockChain.GetById(1);
            Assert.AreEqual(TransactionStatus.Failed, result.Status);
        }

        [Test]
        public void Test_ChangeTransactionStatus_ThrowsErrorWhenAccessing_NonExistantTransaction()
        {
            Assert.Throws<ArgumentException>(() => blockChain.ChangeTransactionStatus(30, TransactionStatus.Failed));
        }

        [Test]
        public void Test_RemoveTransactionById_WorksProperly()
        {
            blockChain.Add(fakeTransaction_One);
            blockChain.Add(fakeTransaction_Two);

            blockChain.RemoveTransactionById(1);

            Assert.AreEqual(1, blockChain.Count);
            Assert.IsFalse(blockChain.Contains(1));
        }

        [Test]
        public void Test_RemoveTransactionById_ThrowsErrorWhenRemovingNonExistantTransaction()
        {
            Assert.Throws<InvalidOperationException>(()=> blockChain.RemoveTransactionById(30));
        }

        [Test]
        public void Test_GetById_WorksProperly()
        {
            blockChain.Add(fakeTransaction_One);
            Assert.AreEqual(fakeTransaction_One, blockChain.GetById(1));
        }

        [Test]
        public void Test_GetById_ThrowsErrorWhenLookingFor_NonExistantTransaction()
        {
            Assert.Throws<InvalidOperationException>(()=> blockChain.GetById(30));
        }

        [Test]
        public void Test_GetByTransactionStatus_WorksProperly()
        {
            blockChain.Add(fakeTransaction_One);
            blockChain.Add(fakeTransaction_Two);
            blockChain.ChangeTransactionStatus(2, TransactionStatus.Failed);

            var result = blockChain.GetByTransactionStatus(TransactionStatus.Failed).ToArray();
            Assert.AreEqual(1, result.Length);
            Assert.AreEqual(fakeTransaction_Two, result[0]);
        }

        [Test]
        public void Test_GetByTransactionStatus_ThrowsErrorWhen_NoItemMatches()
        {
            Assert.Throws<InvalidOperationException>(() => blockChain.GetByTransactionStatus(TransactionStatus.Successfull));
        }

        [Test]
        public void Test_GetAllSendersWithTransactionStatus_WorksProperly()
        {
            blockChain.Add(fakeTransaction_One);

            var result = blockChain.GetAllSendersWithTransactionStatus(TransactionStatus.Successfull).ToArray();
            Assert.AreEqual(1, result.Length);
            Assert.AreEqual(fakeTransaction_One.From, result[0]);
        }
        
        [Test]
        public void Test_GetAllReceiversWithTransactionStatus_ThrowsErrorWhen_NoItemMatches()
        {
            Assert.Throws<InvalidOperationException>(() => blockChain.GetByTransactionStatus(TransactionStatus.Successfull));
        }

        [Test]
        public void Test_GetAllReceiversWithTransactionStatus_WorksProperly()
        {
            blockChain.Add(fakeTransaction_One);

            var result = blockChain.GetAllReceiversWithTransactionStatus(TransactionStatus.Successfull).ToArray();
            Assert.AreEqual(1, result.Length);
            Assert.AreEqual(fakeTransaction_One.To, result[0]);
        }

        [Test]
        public void Test_GetAllSendersWithTransactionStatus_ThrowsErrorWhen_NoItemMatches()
        {
            Assert.Throws<InvalidOperationException>(() => blockChain.GetAllReceiversWithTransactionStatus(TransactionStatus.Successfull));
        }

        [Test]
        public void Test_GetAllOrderedByAmountDescendingThenById_WorksProperly()
        {
            blockChain.Add(fakeTransaction_One);
            blockChain.Add(fakeTransaction_Two);
            blockChain.Add(fakeTransaction_Three);

            var result = blockChain.GetAllOrderedByAmountDescendingThenById().ToArray();
            Assert.IsTrue(result[0].Amount > result[1].Amount);
            Assert.IsTrue(result[1].Id < result[2].Id);
        }

        [Test]
        public void Test_GetBySenderOrderedByAmountDescending_WorksProperly()
        {
            blockChain.Add(fakeTransaction_One);
            blockChain.Add(fakeTransaction_Three);

            var result = blockChain.GetBySenderOrderedByAmountDescending("Daniel").ToArray();
            Assert.IsTrue(result[0].Amount > result[1].Amount);
        }

        [Test]
        public void Test_GetBySenderOrderedByAmountDescending_ThrowsErrorWhen_NoResultsFound()
        {
            Assert.Throws<InvalidOperationException>(() => blockChain.GetBySenderOrderedByAmountDescending("Daniel"));
        }

        [Test]
        public void Test_GetByReceiverOrderedByAmountThenById_WorksProperly()
        {
            blockChain.Add(fakeTransaction_One);
            blockChain.Add(fakeTransaction_Two);
            blockChain.Add(fakeTransaction_Three);
            blockChain.Add(fakeTransaction_Four);

            var result = blockChain.GetByReceiverOrderedByAmountThenById("Robert").ToArray();
            Assert.IsTrue(result[0].Amount > result[1].Amount);
            Assert.IsTrue(result[1].Id < result[2].Amount);
        }

        [Test]
        public void Test_GetByReceiverOrderedByAmountThenById_ThrowsErrorWhen_NoResultsFound()
        {
            Assert.Throws<InvalidOperationException>(() => blockChain.GetByReceiverOrderedByAmountThenById("Robert"));
        }

        [Test]
        public void Test_GetByTransactionStatusAndMaximumAmount_WorksProperly()
        {
            blockChain.Add(fakeTransaction_One);
            blockChain.Add(fakeTransaction_Two);
            blockChain.Add(fakeTransaction_Three);
            fakeTransaction_Four.Amount -= 50;
            blockChain.Add(fakeTransaction_Four);

            var result = blockChain.GetByTransactionStatusAndMaximumAmount(TransactionStatus.Successfull, 60).ToArray();
            Assert.AreEqual(1, result.Length);
            
        }

        [Test]
        public void Test_GetBySenderAndMinimumAmountDescending_WorksProperly()
        {
            blockChain.Add(fakeTransaction_One);
            blockChain.Add(fakeTransaction_Two);
            blockChain.Add(fakeTransaction_Three);
            fakeTransaction_Four.Amount -= 50;
            blockChain.Add(fakeTransaction_Four);

            var result = blockChain.GetBySenderAndMinimumAmountDescending("Daniel", 60).ToArray();

            Assert.AreEqual(2, result.Length);
            Assert.IsTrue(result[0].Amount > result[1].Amount);
        }

        [Test]
        public void Test_GetBySenderAndMinimumAmountDescending_ThrowsErrorWhen_NoResultsFound()
        {
            Assert.Throws<InvalidOperationException>(() => blockChain.GetBySenderAndMinimumAmountDescending("Pepito", 0));
        }

        [Test]
        public void Test_GetByReceiverAndAmountRange_WorksProperly()
        {
            blockChain.Add(fakeTransaction_One);
            blockChain.Add(fakeTransaction_Two);
            blockChain.Add(fakeTransaction_Three);
            fakeTransaction_Four.Amount -= 50;
            blockChain.Add(fakeTransaction_Four);

            var result = blockChain.GetByReceiverAndAmountRange("Robert", 60, 10000).ToArray();

            Assert.AreEqual(2, result.Length);
        }

        [Test]
        public void Test_GetByReceiverAndAmountRange_ThrowsErrorWhen_NoResultsFound()
        {
            Assert.Throws<InvalidOperationException>(() => blockChain.GetByReceiverAndAmountRange("Pepito", 0, 10000));
        }

        [Test]
        public void Test_GetAllInAmountRange_WorksProperly()
        {
            blockChain.Add(fakeTransaction_One);
            blockChain.Add(fakeTransaction_Two);
            blockChain.Add(fakeTransaction_Three);
            fakeTransaction_Four.Amount -= 50;
            blockChain.Add(fakeTransaction_Four);

            var result = blockChain.GetAllInAmountRange(0, 10000).ToArray();

            Assert.AreEqual(4, result.Length);
        }

        [SetUp]
        public void InitialData()
        {
            blockChain = new ChainBlock();


            fakeTransaction_One = new FakeTransaction()
            {
                Id = 1,
                From = "Daniel",
                To = "Robert",
                Amount = 100,
                Status = TransactionStatus.Successfull
            };

            fakeTransaction_Two = new FakeTransaction()
            {
                Id = 2,
                From = "Robert",
                To = "Daniel",
                Amount = 99,
                Status = TransactionStatus.Successfull

            };

            fakeTransaction_Three = new FakeTransaction()
            {
                Id = 3,
                From = "Daniel",
                To = "Robert",
                Amount = 99,
                Status = TransactionStatus.Successfull
            };

            fakeTransaction_Four = new FakeTransaction()
            {
                Id=4,
                From = "Daniel",
                To = "Robert",
                Amount = 99,
                Status = TransactionStatus.Successfull
            };
        }
    }
}
