using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballTeamGenerator
{
    public class Team
    {
        private int rating;
        private string name;
        private List<Player> players;

        public Team(string name)
        {
            this.Name = name;
            players = new List<Player>();     
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
        public int Rating
        {
            get { return CalculateRating(); }
        }

        private int CalculateRating()
        {
            if (players != null && players.Count > 0)
            {
                int rating = (int)(Math.Round(players.Sum(p => p.AverageSkill) / players.Count));
                return rating;
            }
            return 0;
            
        }

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        public void RemovePlayer(string playerName)
        {
            Player playerToRemove = null;

            playerToRemove = players.FirstOrDefault(p => p.Name == playerName);

            if (playerToRemove == null)
            {
                Console.WriteLine($"Player {playerName} is not in {Name} team.");
                return;
            }

            players.Remove(playerToRemove);
            return;
        }

        public override string ToString()
        {
            return $"{Name} - {Rating}";
        }
    }
}
