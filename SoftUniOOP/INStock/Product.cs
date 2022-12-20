using INStock.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace INStock
{
    public class Product : IProduct
    {
        public string Label { get; private set; }

        public decimal Price { get; private set; }

        public int Quantity { get; private set; }

        public int CompareTo(IProduct other)
        {
            return 0;
        }
    }
}
