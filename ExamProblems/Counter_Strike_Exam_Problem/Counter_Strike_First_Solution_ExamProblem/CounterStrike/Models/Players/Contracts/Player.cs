using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CounterStrike.Models.Players.Contracts
{
    public abstract class Player : IPlayer
    {
        private string name;
        private int health;
        private int armor;
        private IGun gun;

        public Player(string username, int health, int armor, IGun gun)
        {
            Username = username;
            Health = health;
            Armor = armor;
            Gun = gun;
        }

        public string Username 
        { 
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerName);
                }

                name = value;
            }
        }
        public int Health 
        { 
            get => health;
            protected set
            {
                //TODO: must be <= or just < ?
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerHealth);
                }

                health = value;
            }

        }
        public int Armor 
        { 
            get => armor;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerArmor);
                }

                armor = value;
            }
        }
        public IGun Gun
        { 
            get => gun;
            set
            {
                if (value == null)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGun);
                }

                gun = value;
            }
        }

        public bool IsAlive
        {
            get
            {
                if (Health > 0)
                {
                    return true;
                }

                else
                {
                    return false;
                }
            }

            protected set
            {
            }
        }

        public void TakeDamage(int points)
        {
            if (Armor >= points)
            {
                Armor -= points;
                return;
            }

            //armor 10, points 15
            //TODO: Is here some wrong?
            if (Armor < points)
            {
                points -= Armor;
                Armor = 0;
                Health -= points;

                if (Health <= 0)
                {
                    IsAlive = false;
                }           
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.GetType().Name}: {Username}");
            sb.AppendLine($"--Health: {Health}");
            sb.AppendLine($"--Armor: {Armor}");
            sb.AppendLine($"--Gun: {Gun.Name}");

            string result = sb.ToString().TrimEnd();

            return result;
        }
    }
}
