using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var randomList = new RandomList() { "1","2","3","4","5","6" };
            Console.WriteLine(randomList.RandomString());
            Console.WriteLine(string.Join(", ", randomList));
        }
    }
}
