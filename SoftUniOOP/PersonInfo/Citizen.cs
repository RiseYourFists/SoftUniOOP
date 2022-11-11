﻿namespace PersonInfo
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Citizen : IPerson
    {
        public Citizen(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }
    }
}
