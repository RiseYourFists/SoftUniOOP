using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telephony
{
    public class SmartPhone : ISmartPhone
    {
        public void Browse(string link)
        {
            var response = 
                (link.ToCharArray().Any(x => char.IsDigit(x) == true)) 
                ? "Invalid URL!" 
                : $"Browsing: {link}!";

            Console.WriteLine(response);
        }

        public void Call(string phoneNumber) 
            => Console.WriteLine($"Calling... {phoneNumber}");
    }
}
