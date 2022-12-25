using Chainblock.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Chainblock
{
    public class ChainBlock : IChainblock
    {
        private readonly Dictionary<int, ITransaction> transactions;

        public ChainBlock()
        {
            transactions = new Dictionary<int, ITransaction>();
        }

        public void Add(ITransaction tx)
        => transactions.Add(tx.Id, tx);

        public bool Contains(ITransaction tx)
            => transactions.ContainsValue(tx);

        public bool Contains(int id)
            => transactions.ContainsKey(id);

        public int Count => transactions.Count;

        public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
        {
            if (!transactions.ContainsKey(id))
                throw new ArgumentException();

            transactions[id].Status = newStatus;
        }

        public void RemoveTransactionById(int id)
        {
            if (!transactions.ContainsKey(id))
                throw new InvalidOperationException();

            transactions.Remove(id);
        }

        public ITransaction GetById(int id)
        {
            if (!transactions.ContainsKey(id))
                throw new InvalidOperationException();

            return transactions[id];
        }

        public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        {
           var result = transactions.Values.Where(tx => tx.Status == status).ToArray();

            if (result.Length == 0)
                throw new InvalidOperationException();

            return result;
        }

        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        {
            var result = transactions.Values.Where(x => x.Status == status).Select(x => x.From).ToArray();

            if (result.Length == 0)
                throw new InvalidEnumArgumentException();

            return result;
        }

        public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
        {
            var result = transactions.Values.Where(x => x.Status == status).Select(x => x.To).ToArray();

            if (result.Length == 0)
                throw new InvalidOperationException();

            return result;
        }
        

        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
        => transactions.Values.OrderByDescending(x => x.Amount).ThenBy(x => x.Id).ToArray();

        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            var result = transactions.Values.Where(x => x.From == sender).OrderByDescending(x => x.Amount).ToArray();

            if (result.Length == 0)
                throw new InvalidOperationException();

            return result;
        }

        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            var result = transactions.Values
                .Where(x => x.To == receiver)
                .OrderByDescending(x => x.Amount)
                .ThenBy(x => x.Id)
                .ToArray();

            if (result.Length == 0)
                throw new InvalidOperationException();

            return result;
        }

        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
            => transactions.Values.Where(x => x.Status == status && x.Amount <= amount).ToArray();

        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
        {
            var result = transactions.Values.Where(x => x.From == sender && x.Amount >= amount).OrderByDescending(x => x.Amount).ToArray();

            if (result.Length == 0)
                throw new InvalidOperationException();

            return result;
        }

        public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
        {
            var result = transactions.Values
                .Where(x => x.To == receiver &&x.Amount >= lo && x.Amount < hi)
                .OrderByDescending(x => x.Amount)
                .ThenBy(x => x.Id)
                .ToArray();

            if (result.Length == 0)
                throw new InvalidOperationException();

            return result;
        }

        public IEnumerable<ITransaction> GetAllInAmountRange(double lo, double hi)
            => transactions.Values.Where(x => x.Amount > lo && x.Amount < hi).ToArray();
            
        public IEnumerator<ITransaction> GetEnumerator()
        {
            foreach (var transaction in transactions.Values)
            {
                yield return transaction;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}
