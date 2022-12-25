using Chainblock.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Chainblock
{
    public class ChainBlock : IChainblock
    {
        private Dictionary<int, ITransaction> transactions;

        public ChainBlock()
        {
            transactions = new Dictionary<int, ITransaction>();
        }

        public int Count => transactions.Count;

        public void Add(ITransaction tx)
        => transactions.Add(tx.Id, tx);

        public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
        => transactions[id].Status = newStatus;

        public bool Contains(ITransaction tx)
            => transactions.ContainsValue(tx);

        public bool Contains(int id)
            => transactions.ContainsKey(id);

        public IEnumerable<ITransaction> GetAllInAmountRange(double lo, double hi)
            => transactions.Values.Where(x => x.Amount >= lo && x.Amount <= hi);

        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
        => transactions.Values.OrderByDescending(x => x.Amount).ThenBy(x => x.Id);

        public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
        => transactions.Values.Where(x => x.Status == status).Select(x => x.To);

        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        => transactions.Values.Where(x => x.Status == status).Select(x => x.From);

        public ITransaction GetById(int id)
            => transactions.Values.FirstOrDefault(x => x.Id == id);

        public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<ITransaction> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void RemoveTransactionById(int id)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
