using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Person
    {
        internal string name;
        internal int age;

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get { return name; } set { name = value; } }
        public virtual int Age { get { return age; }  set {  age = value;}  }

        public override string ToString() => $"Name: {name}, Age: {age}";
    }
}
