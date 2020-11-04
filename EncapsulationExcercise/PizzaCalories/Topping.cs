using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private const double CALORIES = 2;
        private double weight;
        private double calories;
        private string type;

        public Topping(string type, double weight)
        {         
            Type = type;
            Weight = weight;
            calories = CalculateCalories(weight);
        }

        private double Weight
        {
            get { return weight; }
            set 
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{this.Type} weight should be in the range [1..50].");
                }

                weight = value;
            }
        }

        private string Type
        {
            get { return type; }
            set
            {
                if (value != "Meat" && value != "Veggies" && value != "Cheese" && value != "Sauce" &&
                    value != "meat" && value != "veggies" && value != "cheese" && value != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }

                type = value;
            }
        }
        public double Calories
        {
            get { return calories; }
            set { Calories = calories; }
        }

        private double CalculateCalories(double grams)
        {
            double result = CALORIES * grams * TypeModifier();

            return result;
        }

        private double TypeModifier()
        {
            double result = 0;

            if (Type == "Meat" || Type == "meat")
            {
                result = 1.2;
            }

            else if (Type == "Veggies" || Type == "veggies")
            {
                result = 0.8;
            }

            else if (Type == "Cheese" || Type == "cheese")
            {
                result = 1.1;
            }

            else if (Type == "Sauce" || Type == "sauce")
            {
                result = 0.9;
            }

            return result;
        }

    }
}
