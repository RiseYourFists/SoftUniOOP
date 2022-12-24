using INStock.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace INStock
{
    public class ProductStock : IProductStock
    {
        private readonly List<IProduct> stocks = new List<IProduct>();

        public IProduct this[int index] { get => stocks[index]; set => stocks[index] = value; }

        public int Count => stocks.Count;

        public void Add(IProduct product)
        {
            stocks.Add(product);
        }

        public bool Contains(IProduct product)
        => stocks.Contains(product);

        public IProduct Find(int index)
        {
            if (!(index < 0 || index > stocks.Count - 1))
            {
                throw new IndexOutOfRangeException();
            }
            return stocks[index];
        }

        public IEnumerable<IProduct> FindAllByPrice(decimal price)
            => stocks.Where(x => x.Price == price);

        public IEnumerable<IProduct> FindAllByQuantity(int quantity)
            => stocks.Where(x => x.Quantity == quantity);

        public IEnumerable<IProduct> FindAllInRange(decimal lo, decimal hi)
            => stocks.Where(x => x.Price >= lo && x.Price <= hi).OrderByDescending(x => x.Price);

        public IProduct FindByLabel(string label)
            => stocks.FirstOrDefault(x => x.Label == label);

        public IEnumerable<IProduct> FindMostExpensiveProduct(int count)
        {
            var orderedStocks = stocks.OrderByDescending(x => x.Price);
            IEnumerable<IProduct> products = orderedStocks.Take(count);
            return products;
        } 

        public IEnumerator<IProduct> GetEnumerator()
        {
            foreach (var item in stocks)
            {
                yield return item;
            }
        }

        public bool Remove(IProduct product)
            => stocks.Remove(product);

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}
