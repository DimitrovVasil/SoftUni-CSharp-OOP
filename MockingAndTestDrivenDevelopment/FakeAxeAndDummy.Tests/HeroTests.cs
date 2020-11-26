using FakeAxeAndDummy.Tests;
using NUnit.Framework;

[TestFixture]
public class HeroTests
{
    [Test]
    public void HeroXPShouldGainWhenHeIsAttackingAndTargetIsDead()
    {
        FakeWeapon fakeWeapon = new FakeWeapon(50, 50);
        FakeTarget fakeTarget = new FakeTarget(30, 30);
        Hero hero = new Hero("Tisho", fakeWeapon);

        hero.Attack(fakeTarget);

        Assert.That(hero.Experience == 10);
    }
}