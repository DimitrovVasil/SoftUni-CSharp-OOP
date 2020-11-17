using NUnit.Framework;
using System;
using System.Reflection;
using System.Linq;
using CarManager;

namespace Tests
{
    [TestFixture]
    public class CarTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void EmptyConstructorShouldSetFuelAmountToZero()
        {
            Car car = (Car)Activator.CreateInstance(typeof(Car), true);
            Assert.That(car.FuelAmount == 0);
        }

        [Test]
        public void ConstructorShouldWorksCorrectly()
        {

            string make = "Audi";
            string model = "X5";
            double fuelConsumption = 1.5;
            double fuelCapacity = 10.5;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.That(car.Make == make);
            Assert.That(car.Model == model);
            Assert.That(car.FuelConsumption == fuelConsumption);
            Assert.That(car.FuelCapacity == fuelCapacity);
            Assert.That(car.FuelAmount == 0);
        }

        [Test]
        public void ShouldThrowsExceptionWhenMakeIsNull()
        {
            string make = null;
            string model = "X5";
            double fuelConsumption = 1.5;
            double fuelCapacity = 10.5;

            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            });
        }

        [Test]
        public void ShouldThrowsExceptionWhenMakeIsEmpty()
        {
            string make = "";
            string model = "X5";
            double fuelConsumption = 1.5;
            double fuelCapacity = 10.5;

            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            });
        }

        [Test]
        public void ShouldThrowsExceptionWhenModelIsNull()
        {
            string make = "Audi";
            string model = null;
            double fuelConsumption = 1.5;
            double fuelCapacity = 10.5;

            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            });
        }

        [Test]
        public void ShouldThrowsExceptionWhenModelIsEmpty()
        {
            string make = "Audi";
            string model = "";
            double fuelConsumption = 1.5;
            double fuelCapacity = 10.5;

            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            });
        }

        [Test]

        public void ShouldThrowsExceptionWhenFuelConsumptionIsNegative()
        {
            //ArgumentException

            string make = "Audi";
            string model = "X3";
            double fuelConsumption = -1.5;
            double fuelCapacity = 10.5;

            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            });
        }

        [Test]
        public void ShouldThrowsExceptionWhenFuelConsumptionIsZero()
        {
            //ArgumentException

            string make = "Audi";
            string model = "X3";
            double fuelConsumption = 0;
            double fuelCapacity = 10.5;

            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            });
        }

        [Test]
        public void ShouldThrowsExceptionWhenFuelCapacityIsNegative()
        {
            //ArgumentException

            string make = "Audi";
            string model = "X3";
            double fuelConsumption = 1.2;
            double fuelCapacity = -1.5;

            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            });
        }

        [Test]
        public void ShouldThrowsExceptionWhenFuelCapacityIsZero()
        {
            //ArgumentException

            string make = "Audi";
            string model = "X3";
            double fuelConsumption = 1.2;
            double fuelCapacity = 0;

            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            });
        }

        [Test]
        public void ShouldThrowsExceptionWhenFuelForRefuelIsNegative()
        {
            //ArgumentException

            string make = "Audi";
            string model = "X3";
            double fuelConsumption = 1.2;
            double fuelCapacity = 10;
            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.Throws<ArgumentException>(() =>
            {
                car.Refuel(-1);
            });
        }

        [Test]
        public void ShouldThrowsExceptionWhenFuelForRefuelIsZero()
        {
            //ArgumentException

            string make = "Audi";
            string model = "X3";
            double fuelConsumption = 1.2;
            double fuelCapacity = 10;
            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.Throws<ArgumentException>(() =>
            {
                car.Refuel(0);
            });
        }

        [Test]
        public void RefuelingCorrectly()
        {

            string make = "Audi";
            string model = "X3";
            double fuelConsumption = 1.2;
            double fuelCapacity = 10;
            Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            car.Refuel(2);

            Assert.That(car.FuelAmount == 2);
        }

        [Test]
        public void ShouldFullCapacityWhenFuelToRefuelIsMore()
        {
            string make = "Audi";
            string model = "X3";
            double fuelConsumption = 1.2;
            double fuelCapacity = 10;
            Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            car.Refuel(11);

            Assert.That(car.FuelAmount == 10);
        }

        [Test]
        public void ShouldThrowsExceptionWhenFuelIsNotEnough()
        {
            string make = "Audi";
            string model = "X3";
            double fuelConsumption = 2.2;
            double fuelCapacity = 10;

            double distance = 1000;
            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

          //  double fuelNeeded = (distance / 100) * car.FuelConsumption;

            car.Refuel(5);

            Assert.Throws<InvalidOperationException>(() =>
            {
                car.Drive(distance);
            });
        }

        [Test]

        public void ShouldDecreaseFuelWhenThereIsEnoughFuel()
        {
            string make = "Audi";
            string model = "X3";
            double fuelConsumption = 1;
            double fuelCapacity = 100;

            double distance = 200;
            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            //2
            double fuelNeeded = (distance / 100) * car.FuelConsumption;

            car.Refuel(10);
            car.Drive(distance);

            Assert.That(car.FuelAmount == 8);
        }
    }
}