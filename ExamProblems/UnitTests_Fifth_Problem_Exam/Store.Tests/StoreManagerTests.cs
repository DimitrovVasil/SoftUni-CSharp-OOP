using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Store.Tests
{
    public class StoreManagerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ProductShouldCreateCorrectly()
        {
            string name = "Butter";
            int quantity = 10;
            decimal price = 5m;

            Product product = new Product(name, quantity, price);

            Assert.That(product.Name == name);
            Assert.That(product.Quantity == quantity);
            Assert.That(product.Price == price);
        }

        [Test]
        public void CountShouldBeZeroWhenManagerIsCreated()
        {
            string name = "Butter";
            int quantity = 10;
            decimal price = 5m;

            Product product = new Product(name, quantity, price);

            StoreManager manager = new StoreManager();

            Assert.That(manager.Products.Count == 0);
        }

        [Test]
        public void ProductsShouldBeNotNullWhenManagerIsCreated()
        {
            string name = "Butter";
            int quantity = 10;
            decimal price = 5m;

            Product product = new Product(name, quantity, price);

            StoreManager manager = new StoreManager();

            Assert.That(manager.Products != null);
        }

        [Test]
        public void AddProductShouldThrowExceptionWhenProductIsNull()
        {
            Product product = null;

            StoreManager manager = new StoreManager();

            Assert.Throws<ArgumentNullException>(() =>
            {
                manager.AddProduct(product);
            });
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void AddProductShouldThrowExceptionWhenQuantityIsBelowOrEqualsToZero(int quantity)
        {
            string name = "Butter";
            decimal price = 5m;

            Product product = new Product(name, quantity, price);

            StoreManager manager = new StoreManager();

            Assert.Throws<ArgumentException>(() =>
            {
                manager.AddProduct(product);
            });
        }

        [Test]
        public void AddProductShouldWorksCorrectly()
        {
            string name = "Butter";
            int quantity = 10;
            decimal price = 5m;

            Product product = new Product(name, quantity, price);

            StoreManager manager = new StoreManager();
            manager.AddProduct(product);

            Assert.That(manager.Products.Count == 1);
        }

        [Test]
        public void BuyProductShouldThrowExceptionWhenProductIsNull()
        {
            string name = "Butter";
            int quantity = 10;
            decimal price = 5m;

            Product product = new Product(name, quantity, price);

            StoreManager manager = new StoreManager();
            manager.AddProduct(product);

            Assert.Throws<ArgumentNullException>(() =>
            {
                manager.BuyProduct("Washmachine", 5);
            });
        }

        [Test]
        public void BuyProductShouldThrowExceptionWhenQuantityIsMoreThanCurrentQuantity()
        {
            string name = "Butter";
            int quantity = 10;
            decimal price = 5m;

            Product product = new Product(name, quantity, price);

            StoreManager manager = new StoreManager();
            manager.AddProduct(product);

            Assert.Throws<ArgumentException>(() =>
            {
                manager.BuyProduct(product.Name, 11);
            });
        }

        [Test]
        public void BuyProductShouldReduceCurrentQuantityWithGivenQuantity()
        {
            string name = "Butter";
            int quantity = 10;
            decimal price = 5m;

            Product product = new Product(name, quantity, price);

            StoreManager manager = new StoreManager();
            manager.AddProduct(product);
            manager.BuyProduct(product.Name, 6);

            Assert.That(product.Quantity == 4);
        }

        [Test]
        public void BuyProductShouldReturnFinalPrice()
        {
            string name = "Butter";
            int quantity = 10;
            decimal price = 100m;
            decimal expectedPrice = price * 6;

            Product product = new Product(name, quantity, price);

            StoreManager manager = new StoreManager();
            manager.AddProduct(product);
            var actualPrice = manager.BuyProduct(product.Name, 6);

            Assert.That(actualPrice == expectedPrice);
        }

        [Test]
        public void ReturnMostExpensiveProduct()
        {
            string name = "Butter";
            int quantity = 10;
            decimal price = 100m;

            string name2 = "Bread";
            int quantity2 = 5;
            decimal price2 = 150m;

            string name3 = "Meat";
            int quantity3 = 10;
            decimal price3 = 200m;

            Product product = new Product(name, quantity, price);
            Product product2 = new Product(name2, quantity2, price2);
            Product product3 = new Product(name3, quantity3, price3);

            StoreManager manager = new StoreManager();
            manager.AddProduct(product);
            manager.AddProduct(product2);
            manager.AddProduct(product3);

            List<Product> orderedProducts = manager.Products.OrderByDescending(x => x.Price).ToList();
            Product expectedMostExpensive = orderedProducts[0];
            Product actualMostExpensive = manager.GetTheMostExpensiveProduct();

            Assert.That(actualMostExpensive.Price == expectedMostExpensive.Price);
            Assert.That(actualMostExpensive.Name == expectedMostExpensive.Name);
            Assert.That(actualMostExpensive.Quantity == expectedMostExpensive.Quantity);
        }


        [Test]
        public void GetExpensiveMethodShouldReturnNull()
        {
      
            StoreManager manager = new StoreManager();
            List<Product> orderedProducts = manager.Products.OrderByDescending(x => x.Price).ToList();
            Product actualMostExpensive = manager.GetTheMostExpensiveProduct();

            Assert.That(actualMostExpensive == null);
        }
    }
}