using System;
using System.Collections.Generic;
using System.Linq;

namespace Raiding
{
    public class Program
    {
        static void Main(string[] args)
        {
            var heroCount = int.Parse(Console.ReadLine());
            var heroList = new List<BaseHero>();

            for (int i = 0; i < heroCount; i++)
            {
                var name = Console.ReadLine();
                var heroClass = Console.ReadLine();
                BaseHero hero = new Druid("");
                bool isValid = true;

                switch (heroClass)
                {
                    case "Druid":
                        hero = new Druid(name);
                        break;
                    case "Paladin":
                        hero = new Paladin(name);
                        break;
                    case "Rogue":
                        hero = new Rogue(name);
                        break;
                    case "Warrior":
                        hero = new Warrior(name);
                        break;
                    default:
                        Console.WriteLine("Invalid hero!");
                        isValid = false;
                        i--;
                        break;
                }

                if (isValid)
                {
                    heroList.Add(hero);
                }
            }

            
            var bossPower = int.Parse(Console.ReadLine());

            if (heroList.Count == 0)
                return;

            var heroesPower = heroList.Sum(x => x.Power);

            heroList.ForEach(x => Console.WriteLine(x.CastAbility()));
            var finalMsg = (heroesPower >= bossPower) ? "Victory!" : "Defeat...";
            Console.WriteLine(finalMsg);
        }
    }
}
