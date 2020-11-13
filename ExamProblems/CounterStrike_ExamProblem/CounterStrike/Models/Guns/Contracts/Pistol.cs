using System;
using System.Collections.Generic;
using System.Text;

namespace CounterStrike.Models.Guns.Contracts
{
    public class Pistol : Gun
    {
        public Pistol(string name, int bulletsCount) : base(name, bulletsCount)
        {
        }

        public override int Fire()
        {
            if (BulletsCount <= 0)
            {
                return 0;
            }

            BulletsCount--;

            return 1;
        }
    }
}
