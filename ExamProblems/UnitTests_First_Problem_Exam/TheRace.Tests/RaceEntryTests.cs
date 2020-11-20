using NUnit.Framework;
using System;
using TheRace;

namespace TheRace.Tests
{
    [TestFixture]
    public class RaceEntryTests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void UnitCarShouldCreateCorrectly()
        {
            string model = "Audi";
            int horsePower = 56;
            double cubicCentimeters = 4.55;

            UnitCar car = new UnitCar(model, horsePower, cubicCentimeters);

            Assert.That(car.Model == model);
            Assert.That(car.HorsePower == horsePower);
            Assert.That(car.CubicCentimeters == cubicCentimeters);
        }

        [Test]
        public void UnitDriverShouldCreateCorrectly()
        {
            string name = "Tosho";
            string model = "Audi";
            int horsePower = 56;
            double cubicCentimeters = 4.55;

            UnitCar car = new UnitCar(model, horsePower, cubicCentimeters);
            UnitDriver driver = new UnitDriver(name, car);

            Assert.That(driver.Name == name);
            Assert.That(driver.Car.Model == model);
            Assert.That(driver.Car.HorsePower == horsePower);
            Assert.That(driver.Car.CubicCentimeters == cubicCentimeters);
        }

        [Test]
        public void UnitDriverShouldThrowExceptionWhenNameIsNull()
        {
            string name = null;
            string model = "Audi";
            int horsePower = 56;
            double cubicCentimeters = 4.55;

            UnitCar car = new UnitCar(model, horsePower, cubicCentimeters);

            Assert.Throws<ArgumentNullException>(() =>
            {
                UnitDriver driver = new UnitDriver(name, car);
            }); 
        }

        [Test]
        public void RaceEntryShouldCorrectlyInstanted()
        {
            RaceEntry raceEntry = new RaceEntry();

            Assert.That(raceEntry.Counter == 0);
        }

        [Test]
        public void AddDriverMethodShouldThrowExceptionWhenDriverIsNull()
        {
            string model = "Audi";
            int horsePower = 56;
            double cubicCentimeters = 4.55;

            UnitCar car = new UnitCar(model, horsePower, cubicCentimeters);
            UnitDriver driver = null;

            RaceEntry raceEntry = new RaceEntry(); 

            Assert.Throws<InvalidOperationException>(() =>
            {
                raceEntry.AddDriver(driver);
            });
        }

        [Test]
        public void AddDriverMethodShouldThrowExceptionWhenDriverIsExist()
        {
            string name = "Tosho";
            string model = "Audi";
            int horsePower = 56;
            double cubicCentimeters = 4.55;

            UnitCar car = new UnitCar(model, horsePower, cubicCentimeters);
            UnitDriver driver1 = new UnitDriver(name, car);
            UnitDriver driver2 = new UnitDriver(name, car);

            RaceEntry raceEntry = new RaceEntry();
            raceEntry.AddDriver(driver1);

            Assert.Throws<InvalidOperationException>(() =>
            {
                raceEntry.AddDriver(driver2);
            });
        }

        [Test]
        public void AddDriverMethodShouldAddDriverCorrectly()
        {
            string name = "Tosho";
            string model = "Audi";
            int horsePower = 56;
            double cubicCentimeters = 4.55;

            UnitCar car = new UnitCar(model, horsePower, cubicCentimeters);
            UnitDriver driver1 = new UnitDriver(name, car);       

            RaceEntry raceEntry = new RaceEntry();
            raceEntry.AddDriver(driver1);

            Assert.That(raceEntry.Counter == 1);
        }


        [Test]
        public void AddDriverMethodShouldReturnSuccessMsgWhenDriverIsAdded()
        {
            string name = "Tosho";
            string model = "Audi";
            int horsePower = 56;
            double cubicCentimeters = 4.55;

            UnitCar car = new UnitCar(model, horsePower, cubicCentimeters);
            UnitDriver driver1 = new UnitDriver(name, car);

            RaceEntry raceEntry = new RaceEntry();
            string actualMessage = raceEntry.AddDriver(driver1);
            string expectedMessage = "Driver Tosho added in race.";
           
            Assert.That(actualMessage == expectedMessage);
        }

        [Test]
        public void AverageHorseShouldThrowExceptionWhenDriversNumberIsBelow2()
        {
            string name = "Tosho";
            string model = "Audi";
            int horsePower = 56;
            double cubicCentimeters = 4.55;

            UnitCar car = new UnitCar(model, horsePower, cubicCentimeters);
            UnitDriver driver1 = new UnitDriver(name, car);

            RaceEntry raceEntry = new RaceEntry();
            raceEntry.AddDriver(driver1);

            Assert.Throws<InvalidOperationException>(() =>
            {
                raceEntry.CalculateAverageHorsePower();
            });
        }

        [Test]
        public void AverageHorseShouldCalculateCorrectly()
        {
            UnitCar car1 = new UnitCar("Audi", 20, 4.55);
            UnitCar car2 = new UnitCar("BMW", 30, 5.55);
            UnitDriver driver1 = new UnitDriver("Tosho", car1);
            UnitDriver driver2 = new UnitDriver("Gosho", car2);

            RaceEntry raceEntry = new RaceEntry();
            raceEntry.AddDriver(driver1);
            raceEntry.AddDriver(driver2);

            double expectedAverageHorsePower = 25;
            double actualAverageHorsePower = raceEntry.CalculateAverageHorsePower();

            Assert.That(expectedAverageHorsePower == actualAverageHorsePower);
        }
    }
}