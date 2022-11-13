using BorderControl.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var IDs = new List<IBirthable>();

            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                var info = command.Split();

                switch (info[0])
                {
                    case "Citizen":
                        var datetime = info[4].Split('/').Select(int.Parse).ToList();
                        IDs.Add(new Human(info[1], info[2], info[3],new DateTime(datetime[2], datetime[1], datetime[0])));
                        break;
                    case "Pet":
                        datetime = info[2].Split('/').Select(int.Parse).ToList();
                        IDs.Add(new Pet(info[1], new DateTime(datetime[2], datetime[1], datetime[0])));
                        break;
                }
            }

            var year = int.Parse(Console.ReadLine());
            var birthdays = IDs.Where(x => x.BirthDate.Year == year).ToList();
            if (birthdays.Count > 0)
                birthdays.ForEach(x => Console.WriteLine(x.GetYear()));
        }
    }
}
