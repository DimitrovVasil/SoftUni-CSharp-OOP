namespace Computers.Tests
{
    using NUnit.Framework;
    using System;

    public class ComputerTests
    {
        [SetUp]
        public void Setup()
        {
           
           
        }

        [Test]
        public void PartShouldConstructCorrectly()
        {
            string name = "mi6ka";
            decimal price = 26m;
            Part part = new Part(name, price);
            Assert.That(part.Name == name);
            Assert.That(part.Price == price);
        }

        [Test]
        public void ComputerShouldConstructCorrectly()
        {   
            string computerName = "Pravec";
            Computer computer = new Computer(computerName);
            string expectedName = "Pravec";

            Assert.That(computer.Name == expectedName);
            Assert.That(computer.Parts.Count == 0);
        }

        [TestCase("")]
        [TestCase("   ")]
        [TestCase(null)]
        public void NameShoudThrowArgumentExceptionWhenIsNullOrWhitespace(string name)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Computer computer = new Computer(name);
            });
            
        }
        [Test]
        public void AddPartShouldBeCorrectly()
        {
            string name = "mi6ka";
            decimal price = 20m;
            Part part = new Part(name, price);

            string name2 = "klaviatura";
            decimal price2 = 40m;
            Part part2 = new Part(name2, price2);

            string name3 = "monitor";
            decimal price3 = 60m;
            Part part3 = new Part(name3, price3);

            string computerName = "Pravec";
            Computer computer = new Computer(computerName);

            computer.AddPart(part);
            computer.AddPart(part2);
            computer.AddPart(part3);

            Assert.That(computer.Parts.Count == 3);
        }

        [Test]
        public void TotalPriceShouldBe120()
        {
            string name = "mi6ka";
            decimal price = 20m;
            Part part = new Part(name, price);

            string name2 = "klaviatura";
            decimal price2 = 40m;
            Part part2 = new Part(name2, price2);

            string name3 = "monitor";
            decimal price3 = 60m;
            Part part3 = new Part(name3, price3);

            string computerName = "Pravec";
            Computer computer = new Computer(computerName);

            computer.AddPart(part);
            computer.AddPart(part2);
            computer.AddPart(part3);

            Assert.That(computer.TotalPrice == 120);
        }

        [Test]
       public void AddPartShouldThrowExceptionWhenTryAddNullPart()
        {
            string name = "mi6ka";
            decimal price = 20m;
            Part part = new Part(name, price);

            Part part2 = null;

            string computerName = "Pravec";
            Computer computer = new Computer(computerName);

            computer.AddPart(part);         

            Assert.Throws<InvalidOperationException>(() =>
            {
                computer.AddPart(part2);
            });
        }

        [Test]
        public void ShoudDecreasePartsCountWhenRemovePart()
        {
            string name = "mi6ka";
            decimal price = 20m;
            Part part = new Part(name, price);

            string name2 = "klaviatura";
            decimal price2 = 40m;
            Part part2 = new Part(name2, price2);

            string name3 = "monitor";
            decimal price3 = 60m;
            Part part3 = new Part(name3, price3);

            string computerName = "Pravec";
            Computer computer = new Computer(computerName);

            computer.AddPart(part);
            computer.AddPart(part2);
            computer.AddPart(part3);
            computer.RemovePart(part3);

            Assert.That(computer.Parts.Count == 2);
        }

        [Test]
        public void ShoudReturnPartByGivenName()
        {
            string name = "mi6ka";
            decimal price = 20m;
            Part part = new Part(name, price);

            string name2 = "klaviatura";
            decimal price2 = 40m;
            Part part2 = new Part(name2, price2);

            string name3 = "monitor";
            decimal price3 = 60m;
            Part part3 = new Part(name3, price3);

            string computerName = "Pravec";
            Computer computer = new Computer(computerName);

            computer.AddPart(part);
            computer.AddPart(part2);
            computer.AddPart(part3);
            Part targetPart = computer.GetPart(name);

            Assert.That(targetPart.Name == name);
            Assert.That(targetPart.Price == price);
        }
    }
}