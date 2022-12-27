using System;

namespace FluentBuilderInterface
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //This design approach uses recursive generic inheritance
            var employee =  EmployeeBuilderDirector
                .NewEmployee
                .SetName("Bob")
                .SetPosition("Regular Worker")
                .SetSalary(500)
                .Build();

            var employee2 = EmployeeBuilderDirector
                .NewEmployee
                .SetName("Martin")
                .SetPosition("CEO")
                .SetSalary(5000)
                .Build();

            Console.WriteLine(employee);
            Console.WriteLine(employee2);
        }
    }
}
