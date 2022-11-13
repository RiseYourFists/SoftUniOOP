using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl.Contracts
{
    public interface IBirthable
    {
        public DateTime BirthDate{ get; set; }

        public string GetYear();
    }
}
