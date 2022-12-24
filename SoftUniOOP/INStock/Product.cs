using INStock.Contracts;

namespace INStock
{
    public class Product : IProduct
    {
        public string Label { get; private set; }

        public decimal Price { get; private set; }

        public int Quantity { get; private set; }

        public int CompareTo(IProduct other)
        {
            var result = this.Label.CompareTo(other.Label);
            if (result == 0)
            {
                result = this.Price.CompareTo(other.Price);
                if (result == 0)
                {
                    result = this.Quantity.CompareTo(other.Quantity);
                }
            }

            return result;
        }
    }
}
