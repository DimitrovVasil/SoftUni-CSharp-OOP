using NUnit.Framework;
using System;

[TestFixture]
public class DummyTests
{
    [Test]
    public void DummyShouldLosePointsIfIsAttacked()
    {
        int health = 20;
        int experience = 40;
        int attackPoints = 7;

        Dummy dummy = new Dummy(health, experience);

        dummy.TakeAttack(attackPoints);

        Assert.That(dummy.Health, Is.EqualTo(13));
    }

    [Test]

    public void DeadDummyShouldThrowExceptionWhenAttacked()
    {
        int health = 0;
        int experience = 40;
        int attackPoints = 7;

        Dummy dummy = new Dummy(health, experience);

        Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(attackPoints), ("Dummy is dead"));
    }

    [Test]
    public void DeadDummyShouldCanGiveXP()
    {
        int health = 0;
        int experience = 20;

        Dummy dummy = new Dummy(health, experience);

        int expectedXP = 20;
        int actualXP = dummy.GiveExperience();

        Assert.AreEqual(expectedXP, actualXP);   
    }

    [Test]
    public void AliveDummyShouldCantGiveXP()
    {
        int health = 1;
        int experience = 20;

        Dummy dummy = new Dummy(health, experience);

        Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());
    }

}
