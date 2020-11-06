using Raiding.Models;
using System;
using System.Collections.Generic;

namespace Raiding
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<BaseHero> heroes = new List<BaseHero>();

            string heroName = Console.ReadLine();
            string heroType = Console.ReadLine();

            BaseHero hero = null;

            while (true)
            {
                if (!isHeroTypeValid(heroType))
                {
                    Console.WriteLine("Invalid hero!");
                }

                else
                {
                    if (heroType == "Druid")
                    {
                        hero = new Druid(heroName);
                    }

                    else if (heroType == "Paladin")
                    {
                        hero = new Paladin(heroName);
                    }

                    else if (heroType == "Rogue")
                    {
                        hero = new Rogue(heroName);
                    }

                    else if (heroType == "Warrior")
                    {
                        hero = new Warrior(heroName);

                    }

                    heroes.Add(hero);
                }

                if (heroes.Count == n)
                {
                    break;
                }

                heroName = Console.ReadLine();
                heroType = Console.ReadLine();
            }

            int bossPower = int.Parse(Console.ReadLine());
            int heroesPower = 0;

            foreach (BaseHero currentHero in heroes)
            {
                //must cast all heroes?
                Console.WriteLine(currentHero.CastAbility());
                heroesPower += currentHero.Power;
            }

            if (heroesPower >= bossPower)
            {
                Console.WriteLine("Victory!");
            }

            else
            {
                Console.WriteLine("Defeat...");
            }
        }

        private static bool isHeroTypeValid(string heroType)
        {
            if (heroType != "Druid" && heroType != "Paladin" && heroType != "Rogue" && heroType != "Warrior")
            {
                return false;
            }

            return true;
        }
    }
}
