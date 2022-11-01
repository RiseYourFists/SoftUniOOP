using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        public string RandomString()
        {
            var rnd = new Random();
            var index = rnd.Next(0, Count);
            var element = this[index];
            this.RemoveAt(index);
            return element.ToString();
        }
    }
}
