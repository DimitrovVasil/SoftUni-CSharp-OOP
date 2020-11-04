using NUnit.Framework;
using Skeleton;

[TestFixture]
public class HeroTests
{
    [Test]
    public void HeroShouldIncreaseExperienceIfTargetIsDead()
    {
        Hero hero = new Hero("Spiderman");

        int health = 0;
        int experience = 40;

        FakeTarget fakeTarget = new FakeTarget(health, experience);

        int attackPoints = 10;
        int durabilityPoints = 20;
       var givenXP = fakeTarget.GiveExperience();

        //this.experience += target.GiveExperience();
        FakeWeapon fakeWeapon = new FakeWeapon(attackPoints, durabilityPoints);

        hero.Attack(fakeTarget);

        int expectedXP = 40 + givenXP;

        Assert.AreEqual(expectedXP, hero.Experience);

    }
}