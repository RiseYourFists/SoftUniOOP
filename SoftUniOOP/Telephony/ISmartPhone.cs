using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public interface ISmartPhone : IPhone
    {
        void Browse(string link);
    }
}
