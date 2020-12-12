using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Models.Tables
{
    public abstract class Table : ITable
    {
        private List<IBakedFood> foodOrders;
        private List<IDrink> drinkOrders;
        private int capacity;
        private int numberOfPeople;

        public Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            foodOrders = new List<IBakedFood>();
            drinkOrders = new List<IDrink>();
            TableNumber = tableNumber;
            Capacity = capacity;
            PricePerPerson = pricePerPerson;
        }

        public virtual IReadOnlyCollection<IBakedFood> FoodOrders
        { 
            get => this.foodOrders.AsReadOnly();
        }

        public virtual IReadOnlyCollection<IDrink> DrinkOrders
        {
            get => this.drinkOrders.AsReadOnly();
        }

        public int TableNumber { get; }
        public int Capacity 
        { 
            get => this.capacity;

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Capacity has to be greater than 0");
                }

                capacity = value;
            }
        }

        public int NumberOfPeople
        { 
            get => this.numberOfPeople;

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Cannot place zero or less people!");
                }

                numberOfPeople = value;
            }
        }
        public decimal PricePerPerson 
        { 
            get;
        }
        public bool IsReserved { get; private set; }

        public decimal Price 
        {
            get => PricePerPerson * NumberOfPeople;
        }

        public void Clear()
        {
            foodOrders.Clear();
            drinkOrders.Clear();
            IsReserved = false;
            //TODO: Check this => in the setter is state for exception!!!
            numberOfPeople = 0;
        }

        public decimal GetBill()
        {
            //TODO: is this calculation correctly?
            //Must calculate only price without portion?
            return foodOrders.Sum(f => f.Price) + drinkOrders.Sum(d => d.Price);
        }

        public string GetFreeTableInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Table: {TableNumber}");
            sb.AppendLine($"Type: {this.GetType().Name}");
            sb.AppendLine($"Capacity: {Capacity}");
            sb.AppendLine($"Price per Person: {PricePerPerson}");

            var result = sb.ToString().TrimEnd();

            return result;
        }

        public void OrderDrink(IDrink drink)
        {
            drinkOrders.Add(drink);
        }

        public void OrderFood(IBakedFood food)
        {
            foodOrders.Add(food);
        }

        public void Reserve(int numberOfPeople)
        {
            NumberOfPeople += numberOfPeople;
            IsReserved = true;
        }
    }
}
