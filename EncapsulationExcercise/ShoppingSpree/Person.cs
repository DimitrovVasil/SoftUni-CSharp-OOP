using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> products;

        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            products = new List<Product>();
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (value == null || value == "" || value == " " || value == "  ")
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                name = value;
            }
        }  

        public decimal Money
        {
            get { return money; }
            set 
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                money = value;
            }
        }   

        public ReadOnlyCollection<Product> Products
        {
            get { return products.AsReadOnly(); }
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
        }
    }
}
