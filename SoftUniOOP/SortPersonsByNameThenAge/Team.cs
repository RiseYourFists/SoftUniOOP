using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PersonsInfo
{
    public class Team
    {
        private string name;

        private List<Person> firstTeam;
        private List<Person> reserveTeam;

        public Team(string name)
        {
            Name = name;
            firstTeam = new List<Person>();
            reserveTeam = new List<Person>();
        }

        public string Name { get; private set; }
        public IReadOnlyList<Person> FirstTeam { get => firstTeam.AsReadOnly(); }
        public IReadOnlyList<Person> ReserveTeam { get => reserveTeam.AsReadOnly(); }

        public void AddPlayer(Person person)
        {
            if (person.Age < 40)
            {
                firstTeam.Add(person);
                return;
            }

            reserveTeam.Add(person);
        }

        public void TeamCount()
        {
            Console.WriteLine($"First team has {firstTeam.Count} players.");
            Console.WriteLine($"Reserve team has {reserveTeam.Count} players.");
        }
    }
}
