using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Computers.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void ComputerShouldConstructCorrectly()
        {
            string manufacturer = "IBM";
            string model = "Xeon";
            decimal price = 1000m;

            Computer computer = new Computer(manufacturer, model, price);

            Assert.That(computer.Manufacturer == manufacturer);
            Assert.That(computer.Model == model);
            Assert.That(computer.Price == price);
        }

        [Test]
        public void ComputerListShoudBeNotNullWhenObjectIsCreated()
        {
            ComputerManager manager = new ComputerManager();
            Assert.That(manager.Computers != null);
        }

        [Test]
        public void ComputersCountShoudBe1WhenObjectIsAdded()
        {
            string manufacturer = "IBM";
            string model = "Xeon";
            decimal price = 1000m;

            Computer computer = new Computer(manufacturer, model, price);
            ComputerManager manager = new ComputerManager();

            manager.AddComputer(computer);
            Assert.That(manager.Computers.Count == 1);
        }

        [Test]
        public void MethodShouldThrowExceptionWhenComputerIsNull()
        {
            Computer computer = null;
            ComputerManager manager = new ComputerManager();
           
            Assert.Throws<ArgumentNullException>(() =>
            {
                manager.AddComputer(computer);
            });
        }

        [Test]
        public void MethodShouldThrowExceptionWhenManufacturerAndModelExists()
        {
            Computer computer = new Computer("IBM", "Xeon", 1500m);
            Computer computer2 = new Computer("IBM", "Xeon", 2500m);
            
            ComputerManager manager = new ComputerManager();
            manager.AddComputer(computer);

            Assert.Throws<ArgumentException>(() =>
            {
                manager.AddComputer(computer2);
            });
        }

        [Test]
        public void ComputersCountShoudBe1WhenComputerIsRemoved()
        {
            string manufacturer = "IBM";
            string model = "Xeon";
            decimal price = 1000m;

            Computer computer = new Computer(manufacturer, model, price);
            Computer computer2 = new Computer("Intel", "i7", 1400m);
            ComputerManager manager = new ComputerManager();

            manager.AddComputer(computer);
            manager.AddComputer(computer2);

            manager.RemoveComputer("Intel", "i7");
            Assert.That(manager.Computers.Count == 1);
        }

        [Test]
        public void MethodShoudReturnComputerWhenIsRemoved()
        {
            string manufacturer = "IBM";
            string model = "Xeon";
            decimal price = 1000m;

            Computer computer = new Computer(manufacturer, model, price);
            Computer computer2 = new Computer("Intel", "i7", 1400m);
            ComputerManager manager = new ComputerManager();

            manager.AddComputer(computer);
            manager.AddComputer(computer2);

            var returnedComputer = manager.RemoveComputer("Intel", "i7");

            Assert.That(manager.Computers.Count == 1);
            Assert.That(returnedComputer.Manufacturer == "Intel");
            Assert.That(returnedComputer.Model == "i7");
            Assert.That(returnedComputer.Price == 1400m);
        }

        [TestCase(null, "Xeon")]
        [TestCase("IBM", null)]
        public void GetComputerShouldReturnExceptionWhenModelOrManufacturerIsNull(string exampleManufacturer, string exampleModel)
        {
            string manufacturer = "IBM";
            string model = "Xeon";
            decimal price = 1000m;

            Computer computer = new Computer(manufacturer, model, price);
            ComputerManager manager = new ComputerManager();
            manager.AddComputer(computer);

            Assert.Throws<ArgumentNullException>(() =>
            {
                manager.GetComputer(exampleManufacturer, exampleModel);
            });
        }

        [Test]
        public void GetComputerShouldThrowExceptionWhenComputerIsNull()
        {
            string manufacturer = "IBM";
            string model = "Xeon";
            decimal price = 1000m;

            Computer computer = new Computer(manufacturer, model, price);
            ComputerManager manager = new ComputerManager();
            manager.AddComputer(computer);

            Assert.Throws<ArgumentException>(() =>
            {
                manager.GetComputer("Tisho", "Xeon");
            });

            Assert.Throws<ArgumentException>(() =>
            {
                manager.GetComputer("IBM", "SomeModel");
            });
        }

        [Test]
        public void GetComputerShouldReturnComputerCorrectly()
        {
            string manufacturer = "IBM";
            string model = "Xeon";
            decimal price = 1000m;

            Computer computer = new Computer(manufacturer, model, price);
            ComputerManager manager = new ComputerManager();
            manager.AddComputer(computer);

            string expectedManufacturer = "IBM";
            string expectedModel = "Xeon";

            var returnedComputer = manager.GetComputer("IBM", "Xeon");

            Assert.That(returnedComputer.Manufacturer == expectedManufacturer);
            Assert.That(returnedComputer.Model == expectedModel);
        }

        [Test]
        public void GetComputerByManufacturerShouldThrowNullExceptionWhenManufacturerIsNull()
        {
            string manufacturer = "IBM";
            string model = "Xeon";
            decimal price = 1000m;

            Computer computer = new Computer(manufacturer, model, price);
            ComputerManager manager = new ComputerManager();
            manager.AddComputer(computer);

            Assert.Throws<ArgumentNullException>(() =>
            {
                manager.GetComputersByManufacturer(null);
            });
        }

        [Test]
        public void GetComputerByManufacturerShouldReturnCollectionWithCount2()
        {
            string manufacturer = "IBM";
            string model = "Xeon";
            decimal price = 1000m;

            string manufacturer2 = manufacturer;
            string model2 = "SomeModel";
            decimal price2 = 1500m;

            string manufacturer3 = "NVIDIA";
            string model3 = "nVidiaModel";
            decimal price3 = 2500m;

            Computer computer = new Computer(manufacturer, model, price);
            Computer computer2 = new Computer(manufacturer2, model2, price2);
            Computer computer3 = new Computer(manufacturer3, model3, price3);
            ComputerManager manager = new ComputerManager();

            manager.AddComputer(computer);
            manager.AddComputer(computer2);
            manager.AddComputer(computer3);

            List<Computer> filteredComputers = (List<Computer>)(manager.GetComputersByManufacturer("IBM"));

            Assert.That(filteredComputers.Count == 2);

            Assert.That(filteredComputers[0].Manufacturer == "IBM");
            Assert.That(filteredComputers[1].Manufacturer == "IBM");

            Assert.That(filteredComputers[0].Model == "Xeon");
            Assert.That(filteredComputers[1].Model == "SomeModel");
        }
    }
}