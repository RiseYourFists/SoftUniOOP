﻿using BorderControl.Contracts;
using System;

namespace BorderControl
{
    public class Human : IIdentifiable, IBirthable
    {
        public Human(string name, string age, string id, DateTime birthDate)
        {
            Name = name;
            Age = age;
            Id = id;
            BirthDate = birthDate;
        }

        public string Name { get; set; }

        public string Age { get; set; }

        public string Id { get; set; }

        public DateTime BirthDate { get; set; }

        public string GetYear()
            => $"{BirthDate.Day:d2}/{BirthDate.Month:d2}/{BirthDate.Year}";
    }
}
