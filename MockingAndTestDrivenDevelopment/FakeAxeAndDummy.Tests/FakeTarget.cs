using System;
using System.Collections.Generic;
using System.Text;

namespace FakeAxeAndDummy.Tests
{
    public class FakeTarget : ITarget
    {

        private int health;
        private int experience;

        public FakeTarget(int health, int experience)
        {
            this.health = health;
            this.experience = experience;
        }

        public int Health => health;

        public int GiveExperience()
        {
            return 10;
        }

        public bool IsDead()
        {
            return true;
        }

        public void TakeAttack(int attackPoints)
        {
            throw new NotImplementedException();
        }
    }
}
