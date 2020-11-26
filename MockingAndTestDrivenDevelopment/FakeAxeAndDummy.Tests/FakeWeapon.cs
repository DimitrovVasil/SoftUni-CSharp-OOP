using System;
using System.Collections.Generic;
using System.Text;

namespace FakeAxeAndDummy.Tests
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
        public int AttackPoints => attackPoints;

        public int DurabilityPoints => durabilityPoints;

        public void Attack(ITarget target)
        {
            
        }
    }
}
