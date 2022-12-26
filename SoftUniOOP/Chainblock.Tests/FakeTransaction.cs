﻿using Chainblock.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chainblock.Tests
{
    public class FakeTransaction : ITransaction
    {
       

        public int Id { get; set; }

        public TransactionStatus Status { get; set; }

        public string From { get; set; }

        public string To { get; set; }

        public double Amount { get; set; }

    }
}
