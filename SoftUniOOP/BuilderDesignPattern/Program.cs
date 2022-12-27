using System;

namespace BuilderDesignPattern
{
    public class Program
    {
        static void Main(string[] args)
        {
            var person = new PersonBuilder()
                .SetName("Bob")
                .SetAge(32)
                .SetGender(Gender.Male)
                .Build();
                

            Console.WriteLine(person);
        }
    }
}
