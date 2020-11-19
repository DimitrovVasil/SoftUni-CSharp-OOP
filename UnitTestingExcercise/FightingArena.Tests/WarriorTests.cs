using NUnit.Framework;
using System;
using FightingArena;

namespace Tests
{
    [TestFixture]
    public class WarriorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("Tisho", 10, 50)]
        public void ConstructorShouldWorksCorrectly(string name, int damage, int hp)
        {
            Warrior warrior = new Warrior(name, damage, hp);

            Assert.AreEqual(name, warrior.Name);
            Assert.AreEqual(damage, warrior.Damage);
            Assert.AreEqual(hp, warrior.HP);      
        }

        [TestCase("   ", 10, 50)]
        [TestCase("", 10, 50)]
        [TestCase(null, 10, 50)]
        public void NameShouldThrowsArgumentException(string name, int damage, int hp)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, damage, hp);
            });
        }

        [TestCase("Pesho", -1, 50)]
        [TestCase("Pesho", 0, 50)]
        [TestCase("Pesho", -10, 50)]
        public void DamageShouldThrowsArgumentException(string name, int damage, int hp)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, damage, hp);
            });
        }

        [TestCase("Pesho", 10, -1)]
        public void HPShouldThrowsArgumentException(string name, int damage, int hp)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, damage, hp);
            });
        }

        [TestCase("Pesho", 40, 10)]
        [TestCase("Pesho", 40, 29)]
        [TestCase("Pesho", 40, 30)]

        public void WarriorShouldThrowExceptionWhenHisHPAreBelowOrEqual30AndTryAttack(string name, int damage, int hp)
        {
            Warrior warrior1 = new Warrior(name, damage, hp);
            Warrior warrior2 = new Warrior("Tosho", 50, 40);

            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior1.Attack(warrior2);
            });
        }

        [TestCase("Pesho", 40, 10)]
        [TestCase("Pesho", 40, 29)]
        [TestCase("Pesho", 40, 30)]

        public void WarriorShouldThrowExceptionWhenVictimHPAreBelowOrEqual30AndTryAttack(string name, int damage, int hp)
        {
            Warrior warrior1 = new Warrior("Tosho", 50, 40);
            Warrior warrior2 = new Warrior(name, damage, hp);

            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior1.Attack(warrior2);
            });
        }

        [TestCase("Pesho", 60, 10)]
        public void WarriorShouldThrowExceptionWhenVictimDamageAreBiggerThanHisHP(string name, int damage, int hp)
        {
            Warrior warrior1 = new Warrior("Tosho", 50, 40);
            Warrior warrior2 = new Warrior(name, damage, hp);

            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior1.Attack(warrior2);
            });
        }

        [Test]
        public void WarriorShouldLoseHP()
        {
            Warrior attacker = new Warrior("Tosho", 60, 80);
            Warrior victim = new Warrior("Pesho", 45, 40);

            attacker.Attack(victim);

            Assert.That(attacker.HP == 35);
        }

        [Test]
        public void EnemyHPShouldBecome0WhenWarriorDamageIsBigger()
        {
            Warrior attacker = new Warrior("Tosho", 80, 80);
            Warrior enemy = new Warrior("Pesho", 60, 50);
            attacker.Attack(enemy);
            Assert.That(enemy.HP == 0);
        }

        [Test]
        public void EnemyHPShouldDecreaseWithWarriorDamageWhenIsBigger()
        {
            Warrior attacker = new Warrior("Tosho", 40, 80);
            Warrior enemy = new Warrior("Pesho", 60, 50);
            attacker.Attack(enemy);
            Assert.That(enemy.HP == 10);
        }

        [Test]
        public void EnemyHPShouldDecreaseWithWarriorDamageWhenIsEqual()
        {
            Warrior attacker = new Warrior("Tosho", 40, 80);
            Warrior enemy = new Warrior("Pesho", 60, 40);
            attacker.Attack(enemy);
            Assert.That(enemy.HP == 0);
        }
    }
}