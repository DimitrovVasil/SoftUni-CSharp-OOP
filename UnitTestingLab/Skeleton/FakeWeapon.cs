using System;
using System.Collections.Generic;
using System.Text;

namespace Skeleton
{
    public class FakeWeapon : IWeapon
    {
        private int attackPoints;
        private int durabilityPoints;

        public FakeWeapon(int attack, int durability)
        {
            this.attackPoints = attack;
            this.durabilityPoints = durability;
        }

        public int AttackPoints
        {
            get { return this.attackPoints; }
        }

        public int DurabilityPoints
        {
            get { return this.durabilityPoints; }
        }

        public void Attack(ITarget target)
        {
            if (this.durabilityPoints <= 0)
            {
                throw new InvalidOperationException("Weapon is broken.");
            }

            target.TakeAttack(this.attackPoints);
            this.durabilityPoints -= 1;
        }
    }
}
