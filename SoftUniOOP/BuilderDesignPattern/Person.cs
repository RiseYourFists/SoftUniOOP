using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderDesignPattern
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }

        public override string ToString()
        => $"Name: {Name}\nAge: {Age}\nGender: {Gender}";
    }

    public enum Gender
    {
        Male,
        Female
    }
}
