using System;
using System.Collections.Generic;
using System.Text;

namespace Chainblock.Contracts
{
    public class Transaction : ITransaction
    {
        public Transaction(int id, string from, string to, double amount, TransactionStatus status)
        {
            Id = id;
            From = from;
            To = to;
            Amount = amount;
            Status = status;
        }

        public int Id { get; set; }

        public string From { get; set; }

        public string To { get; set; }

        public double Amount { get; set; }

        public TransactionStatus Status { get; set; }
    }
}
