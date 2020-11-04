using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters
{
    public class Hero
    {
        private int level;
        private int username;

        public Hero(string username, int level)
        {
            Level = level;
            Username = username;
        }

        public int Level
        {
            get { return level; }
            set { level = value; }
        }

        public string Username { get; set; }

        public override string ToString()
        {
            return $"Type: {this.GetType().Name} Username: {this.Username} Level: {this.Level}";
        }

    }
}
