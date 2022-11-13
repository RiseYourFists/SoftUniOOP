using BorderControl.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Pet : IBirthable
    {
        public Pet(string name, DateTime birthDate)
        {
            Name = name;
            BirthDate = birthDate;
        }

        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public string GetYear()
            => $"{BirthDate.Day:d2}/{BirthDate.Month:d2}/{BirthDate.Year}";
    }
}
