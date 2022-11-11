using System;
using System.Linq;

namespace Telephony
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var smartPhone = new SmartPhone();
            var stationaryPhone = new StationaryPhone();

            var phonenumbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var webSites = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in phonenumbers)
            {
                if (item.ToCharArray().Any(x => char.IsLetter(x) == true))
                {
                    Console.WriteLine("Invalid number!");
                    continue;
                }

                if(item.Length == 7)
                    stationaryPhone.Call(item);
                else if(item.Length == 10)
                    smartPhone.Call(item);
            }

            foreach (var item in webSites)
            {
                smartPhone.Browse(item);
            }
        }
    }
}
