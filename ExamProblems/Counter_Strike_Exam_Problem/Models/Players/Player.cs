using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Players.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CounterStrike.Models.Players
{
    public abstract class Player : IPlayer
    {
        private string username;
        private int health;
        private int armor;
        private IGun gun;
        private bool isAlive;

        public Player(string username, int health, int armor, IGun gun)
        {
            Username = username;
            Health = health;
            Armor = armor;
            Gun = gun;
            IsAlive = true;
        }

        public string Username 
        {
            get => this.username;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Username cannot be null or empty.");
                }

                username = value;
            }
        }

        public int Health
        {
            get => this.health;

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Player health cannot be below or equal to 0.");
                }

                health = value;
            }
        }

        public int Armor
        {
            get => this.armor;

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Player armor cannot be below 0.");
                }

                armor = value;
            }
        }

        public IGun Gun
        {
            get => this.gun;

            private set
            {
                if (value == null)
                {
                    throw new ArgumentException("Gun cannot be null or empty.");
                }

                gun = value;
            }
        }
        public bool IsAlive 
        {
            get 
            {
                return this.isAlive;
            }

            private set
            {
                if (health > 0)
                {
                    isAlive = true;
                }

                else
                {
                    isAlive = false;
                }
            }
        }

        public void TakeDamage(int points)
        {
            if (armor - points < 0)
            {
                int resultToSubtractFromHealth = Armor - points;
                armor = 0;

                if (health - resultToSubtractFromHealth <= 0)
                {
                    health = 0;   
                }

                else
                {
                    health -= resultToSubtractFromHealth;
                }

                if (health <= 0)
                {
                    IsAlive = false;
                }

                else
                {
                    IsAlive = true;
                }
            }

            else
            {
                armor -= points;
                isAlive = true;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.GetType().Name}: {this.Username}");
            sb.AppendLine($"--Health: {this.Health}");
            sb.AppendLine($"--Armor: {this.Armor}");
            sb.AppendLine($"--Gun: {this.Gun.Name}");

            return sb.ToString().TrimEnd();
        }
    }
}
