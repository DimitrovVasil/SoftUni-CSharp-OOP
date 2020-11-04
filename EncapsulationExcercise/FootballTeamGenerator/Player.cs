using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace FootballTeamGenerator
{
    public class Player
    {
        private double averageSkill;
        private string name;

        public Player(string name, Stats stats)
        {
            this.Name = name;
            Stats = stats;
            averageSkill = CalculateAverageSkill(this.Stats);
        }

        public string Name
        {
            get 
            {
                return name;
            }
            set 
            {
                if (value == "" || value == null || value == " " || value == "  ")
                {
                    throw new Exception("A name should not be empty.");
                }

                name = value;
            }
        }

        
        public Stats Stats { get; private set; }
        public double AverageSkill
        {
            get
            {
                return averageSkill;
            }
        }
        

        private double CalculateAverageSkill(Stats stats)
        {
            //endurance, sprint, dribble, passing and shooting. 
            double averageSkill = 
                (stats.Endurance 
                + stats.Sprint 
                + stats.Dribble 
                + stats.Passing 
                + stats.Shooting) 
                * 1.0 / 5;

            return averageSkill;
        }
    }
}
