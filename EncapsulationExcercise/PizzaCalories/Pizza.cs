using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
   public class Pizza
    {

        private string name;
        private List<Topping> toppings;
        private Dough dough;
        private double totalCalories;



        public Pizza(string name, Dough dough, List<Topping> toppings)
        {
            Name = name;
            Dough = dough;
            Toppings = toppings;
            totalCalories = CalculateTotalCalories();
        }

        public string Name
        {
            get { return name; }
            set 
            {
                if (value.Length == 0 || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }

                name = value;
            }
        }

        public List<Topping> Toppings
        {
            get { return toppings; }
            set { toppings = value; }
        }

        public Dough Dough
        {
            get { return dough; }
            set { dough = value; }
        }

        public double TotalCalories
        {
            get { return totalCalories; }
            set { TotalCalories = totalCalories; }
        }

        private double CalculateTotalCalories()
        {
            double toppingCalories = 0;

            foreach (var topping in Toppings)
            {
                toppingCalories += topping.Calories;
            }

            double totalCalories = Dough.Calories + toppingCalories;

            return totalCalories;
        }

        public void AddTopping(Topping topping)
        {
            Toppings.Add(topping);

            if (Toppings.Count > 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }    
        }




    }
}
