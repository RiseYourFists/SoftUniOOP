using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl.Contracts
{
    public interface IBuyable
    {
        public int FoodSupply { get; set; }

        public void BuyFood();
    }
}
