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
            var IDs = new List<IIdentifiable>();

            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                var info = command.Split();

                if (info.Length == 3)
                {
                    IDs.Add(new Human(info[0], info[1], info[2]));  
                }
                else if (info.Length == 2)
                {
                    IDs.Add(new Robot(info[0], info[1]));
                }
            }

            var fakeID = Console.ReadLine();
            var fakeIDs = IDs.Where(x => x.Id[(x.Id.Length - fakeID.Length)..] == fakeID).ToList();

            fakeIDs.ForEach(x => Console.WriteLine(x.Id));
        }
    }
}
