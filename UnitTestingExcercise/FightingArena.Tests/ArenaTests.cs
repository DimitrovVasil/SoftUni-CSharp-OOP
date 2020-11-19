using NUnit.Framework;
using FightingArena;
using System;

namespace Tests
{
    public class ArenaTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void WarriorListShouldBeNotNullWhenArenaIsIntancing()
        {
            Arena arena = new Arena();

            Assert.That(arena.Warriors != null);
        }

        [Test]
        public void ShouldReturnThatCountIs1()
        {
            Arena arena = new Arena();
            Warrior warrior = new Warrior("Djukata", 40, 50);
            arena.Enroll(warrior);

            Assert.That(arena.Count == 1);
        }

        [Test]
        public void ArenaShouldThrowExceptionWhenTryToAddWarriorAlreadyExisting()
        {
            Arena arena = new Arena();
            Warrior warrior1 = new Warrior("Djukata", 40, 50);
            Warrior warrior2 = new Warrior("Djukata", 60, 70);
            arena.Enroll(warrior1);
            
            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Enroll(warrior2);
            });
        }

        [Test]
        public void ArenaShouldAddWarriorSuccessfully()
        {
            Arena arena = new Arena();
            Warrior warrior1 = new Warrior("Djukata", 40, 50);
            Warrior warrior2 = new Warrior("Bitalsa", 60, 70);
            arena.Enroll(warrior1);
            arena.Enroll(warrior2);

            Assert.That(arena.Warriors.Count == 2);
        }

        [TestCase(null, "Tosho")]
        [TestCase("Tosho", null)]
        [TestCase("Tosho", "Denko")]
        [TestCase("Denko", "Tosho")]

        public void ShouldThrowExceptionWhenWarriorIsMissing(string firstWarrior, string secondWarrior)
        {
            Warrior warrior1 = new Warrior("Tosho", 40, 50);
            Warrior warrior2 = new Warrior("Gosho", 60, 70);

            Arena arena = new Arena();

            arena.Enroll(warrior1);
            arena.Enroll(warrior2);

            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Fight(firstWarrior, secondWarrior);
            });

        }

      
        [TestCase("Valio", "Gosho")]
        public void ShouldReturnFirstWarriorAsMissing(string firstWarrior, string secondWarrior)
        {
            Warrior warrior1 = new Warrior("Tosho", 40, 50);
            Warrior warrior2 = new Warrior("Gosho", 60, 70);

            Arena arena = new Arena();

            arena.Enroll(warrior1);
            arena.Enroll(warrior2);

            var expectedException = $"There is no fighter with name {firstWarrior} enrolled for the fights!";
            var actualException = Assert.Throws<InvalidOperationException>(() => arena.Fight(firstWarrior, secondWarrior));
            Assert.AreEqual (expectedException, actualException.Message);
        }
    }
}
