using OnlineShop.Common.Constants;
using OnlineShop.Models.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Models
{
    public abstract class Product : IProduct
    {
        private int id;
        private string manufacturer;
        private string model;
        private decimal price;
        private double overallPerformance;

        public Product(int id, string manufacturer, string model, decimal price, double overallPerformance)
        {
            Id = id;
            Manufacturer = manufacturer;
            Model = model;
            Price = price;
            OverallPerformance = overallPerformance;
        }

        public int Id
        { 
            get
            {
                return id;
            } 
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidProductId);
                }

                id = value;
            } 
        }

        public string Manufacturer
        {
            get
            {
                return manufacturer;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidManufacturer);
                }

                manufacturer = value;
            }
        }

        public string Model
        {
            get
            {
                return model;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidModel);
                }

                model = value;
            }
        }

        public virtual decimal Price
        {
            get
            {
                return price;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPrice);
                }

                price = value;
            }
        }

        public virtual double OverallPerformance
        {
            get
            {
                return overallPerformance;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidOverallPerformance);
                }

                overallPerformance = value;
            }
        }
        public override string ToString()
        {
            return $"Overall Performance: {OverallPerformance}. Price: {Price} - {this.GetType().Name}: {Manufacturer} {Model} (Id: {Id})";

        }
    }
}
