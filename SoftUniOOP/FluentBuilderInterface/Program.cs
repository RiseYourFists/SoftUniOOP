using System;

namespace FluentBuilderInterface
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var employee =  EmployeeBuilderDirector
                .NewEmployee
                .SetName("Bob")
                .SetPosition("Regular Worker")
                .SetSalary(500)
                .Build();

            Console.WriteLine(employee);
        }
    }
}
