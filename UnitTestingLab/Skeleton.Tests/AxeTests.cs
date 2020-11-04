using NUnit.Framework;
using System;

[TestFixture]
public class AxeTests
{
    [Test]
    public void WeaponShouldLoseDurabilityAfterAttack()
    {
        //arrange
        int durability = 10;
        int damage = 5;
        Axe axe = new Axe(damage, durability);

        int health = 3;
        int experience = 2;
        Dummy dummy = new Dummy(health, experience);

        int expectedDurability = 9;
 
        //action
        axe.Attack(dummy);

        //assert
        Assert.AreEqual(expectedDurability, axe.DurabilityPoints);
    }

    [Test]

    public void WeaponShouldReturnExceptionWhenDurabilityPointsAreBelowZero()
    {
        //arrange
        int durability = -4;
        int damage = 5;
        Axe axe = new Axe(damage, durability);

        int health = 3;
        int experience = 2;
        Dummy dummy = new Dummy(health, experience);


        //assert
        Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy));
    }

    [Test]
    public void WeaponShouldReturnExceptionWhenDurabilityPointsAreZero()
    {
        //arrange
        int durability = 0;
        int damage = 5;
        Axe axe = new Axe(damage, durability);

        int health = 3;
        int experience = 2;
        Dummy dummy = new Dummy(health, experience);


        //assert
        Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy));
    }
}