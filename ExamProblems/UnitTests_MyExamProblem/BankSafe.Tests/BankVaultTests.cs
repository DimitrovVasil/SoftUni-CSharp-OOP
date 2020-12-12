using NUnit.Framework;
using System;

namespace BankSafe.Tests
{
    [TestFixture]
    public class BankVaultTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void BankItemShouldCreateCorrectly()
        {
            string owner = "Tisho";
            string id = "10";

            Item item = new Item(owner, id);

            Assert.That(item.Owner == owner);
            Assert.That(item.ItemId == id);
        }

        [Test]
        public void BankVaultShouldCreateCorrectly()
        {
            BankVault vault = new BankVault();

            Assert.That(vault.VaultCells.Count == 12);
            Assert.That(vault.VaultCells["A1"] == null);
            Assert.That(vault.VaultCells.ContainsKey("C4"));
        }

        [Test]
        public void AddItemShouldThrowException_WhenCellNotExist()
        {
            Item item = new Item("Pesho", "10");
            string cell = "Ghostkid";
            BankVault vault = new BankVault();

            Assert.Throws<ArgumentException>(() =>
            {
                vault.AddItem(cell, item);
            });
        }

        [Test]
        public void AddItemShouldThrowException_WhenCellIsNotNull()
        {
            Item item = new Item("Pesho", "10");
            Item item2 = new Item("Tisho", "11");

            string cell = "A1";
            BankVault vault = new BankVault();
            vault.AddItem(cell, item);

            Assert.Throws<ArgumentException>(() =>
            {
                vault.AddItem(cell, item2);
            });
        }

        [Test]
        public void AddItemShouldThrowException_WhenItemIsAlreadyInCell()
        {
            Item item = new Item("Pesho", "10");
            Item item2 = new Item("Tisho", "11");

            string cell = "A1";
            string cell2 = "B1";
            BankVault vault = new BankVault();
            vault.AddItem(cell2, item);

            Assert.Throws<InvalidOperationException>(() =>
            {
                vault.AddItem(cell, item);
            });
        }

        [Test]
        public void AddItemShouldWorkCorrectly_WhenAllIsCorrect()
        {
            Item item = new Item("Pesho", "10");
            Item item2 = new Item("Tisho", "11");

            string cell = "A1";
            string cell2 = "B1";
            BankVault vault = new BankVault();
            vault.AddItem(cell, item);
            vault.AddItem(cell2, item2);

            Assert.That(vault.VaultCells[cell] == item);
            Assert.That(vault.VaultCells[cell2] == item2);
        }

        public void AddItemShouldReturnMessage_WhenAllIsCorrect()
        {
            Item item = new Item("Pesho", "10");
            Item item2 = new Item("Tisho", "11");

            string cell = "A1";
            string cell2 = "B1";
            BankVault vault = new BankVault();
            vault.AddItem(cell, item);
           
            string actualResult = vault.AddItem(cell2, item2);
            string expectedResult = $"Item:{item2.ItemId} saved successfully!";

            Assert.That(expectedResult == actualResult);      
        }

        [Test]
        public void RemoveItemShouldThrowException_WhenCellNotExist()
        {
            Item item = new Item("Pesho", "10");
            string cell = "Tisho";
            BankVault vault = new BankVault();

            Assert.Throws<ArgumentException>(() =>
            {
                vault.RemoveItem(cell, item);
            });
        }

        [Test]
        public void RemoveItemShouldThrowException_WhenCellValueIsNotEqualToGivenItem()
        {
            Item item = new Item("Pesho", "10");
            Item item2 = new Item("Gosho", "12");
            string cell = "A1";
            BankVault vault = new BankVault();

            vault.AddItem(cell, item);

            Assert.Throws<ArgumentException>(() =>
            {
                vault.RemoveItem(cell, item2);
            });
        }

        [Test]
        public void RemoveItemShouldWorkCorrectly()
        {
            Item item = new Item("Pesho", "10");
            string cell = "A1";
            BankVault vault = new BankVault();

            vault.AddItem(cell, item);
            vault.RemoveItem(cell, item);

            Assert.That(vault.VaultCells[cell] == null);
        }

        [Test]
        public void RemoveItemShouldReturnMessageWhenRemoveIsCorrectly()
        {
            Item item = new Item("Pesho", "10");

            string cell = "A1";
            BankVault vault = new BankVault();

            vault.AddItem(cell, item);
            string actualMessage = vault.RemoveItem(cell, item);
            string expectedMessage = $"Remove item:{item.ItemId} successfully!";

            Assert.That(actualMessage == expectedMessage);
        }
    }
}