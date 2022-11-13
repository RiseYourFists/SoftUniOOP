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
            var IDs = new Dictionary<string, IBuyable>();

            var n = int.Parse(Console.ReadLine());

            for(int i = 0; i < n; i++)    
            {
                var info = Console.ReadLine().Split();

                switch (info.Length)
                {
                    case 4:
                        if (!IDs.ContainsKey(info[0]))
                        {
                            var datetime = info[3].Split('/').Select(int.Parse).ToList();
                            IDs.Add(info[0], new Citizen(info[0], info[1], info[2], new DateTime(datetime[2], datetime[1], datetime[0])));
                        }
                        break;
                    case 3:
                        if (!IDs.ContainsKey(info[0]))
                        {
                            IDs.Add(info[0], new Rebel(info[0], info[1], info[2]));
                        }
                        break;
                }
            }

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                if (IDs.ContainsKey(command))
                {
                    IDs[command].BuyFood();
                }
            }

            Console.WriteLine(IDs.Values.Sum(x => x.FoodSupply));
        }
    }
}
