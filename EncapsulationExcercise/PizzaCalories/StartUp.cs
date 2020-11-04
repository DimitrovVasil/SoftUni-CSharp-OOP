using System;
using System.Collections.Generic;

namespace PizzaCalories
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] cmdPizza = Console.ReadLine().Split();
            string classPizza = cmdPizza[0];
            string pizzaName = cmdPizza[1];

            string[] cmdDough = Console.ReadLine().Split();
            string classDough = cmdDough[0];
            string flour = cmdDough[1];
            string bakingTechnique = cmdDough[2];
            double grams = double.Parse(cmdDough[3]);

            List<Topping> toppings = new List<Topping>();

            string cmd = Console.ReadLine();

            while (cmd != "END")
            {
                string[] splitted = cmd.Split();

                string className = splitted[0];
                string toppingType = splitted[1];
                double weight = double.Parse(splitted[2]);

                try
                {
                    if (toppings.Count == 10)
                    {
                        Console.WriteLine("Number of toppings should be in range [0..10].");
                        return;
                    }

                    else
                    {
                        Topping topping = new Topping(toppingType, weight);
                        toppings.Add(topping);
                    }
                    
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }

                cmd = Console.ReadLine();
            }

            try
            {
                Dough dough = new Dough(flour, bakingTechnique, grams);
                Pizza pizza = new Pizza(pizzaName, dough, toppings);
                Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories.ToString("0.00")} Calories.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }
    }
}
