using CounterStrike.Models.Guns.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CounterStrike.Models.Guns
{
    public abstract class Gun : IGun
    {
        private string name;
        private int bulletsCount;

        public Gun(string name, int bulletsCount)
        {
            Name = name;
            BulletsCount = bulletsCount;
        }

        public string Name 
        {
            get => this. name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Gun cannot be null or empty.");
                }

                name = value;
            }
        }

        public int BulletsCount 
        { 
            get => this.bulletsCount;

            //TODO: must think about virtual property?
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Bullets cannot be below 0.");
                }
            }
        }

        public abstract int Fire();
    }
}
