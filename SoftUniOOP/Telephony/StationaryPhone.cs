using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class StationaryPhone : IPhone
    {
        public void Call(string phoneNumber)
            => Console.WriteLine($"Dialing... {phoneNumber}");
    }
}
