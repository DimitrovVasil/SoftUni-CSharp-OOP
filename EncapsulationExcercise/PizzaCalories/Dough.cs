using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private const double CALORIES = 2;

        private string flour;
        private string bakingTechnique;
        private double weight;
        private double calories;

        public Dough(string flour, string bakingTechnique, double grams)
        {
            this.Flour = flour;
            this.BakingTechnique = bakingTechnique.ToLower();
            this.Weight = grams;
            this.calories = CalculateCalories(grams);
        }

        public double Weight 
        {
            get
            {
                return weight;
            }
            set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range[1..200].");
                }

                weight = value;
            }
        }

        public double Calories 
        {
            get
            { 
                return calories;
            }
            set 
            {
                Calories = calories;
            }
        }

        private string Flour
        {
            get
            {
                return this.flour;
            }

            set
            {
                if (value == "Wholegrain" || value == "White" || value == "wholegrain" || value == "white")
                {
                    this.flour = value;
                }

                else
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

               
            }
        }

        private string BakingTechnique
        { 
            get
            {
                return bakingTechnique;
            }

            set 
            {
                if (value != "Crispy" && value != "Chewy" && value != "Homemade" &&
                    value != "crispy" && value != "chewy" && value != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                bakingTechnique = value;
            }
        }

        private double CalculateCalories(double grams)
        {
            double flourModifier = 0;
            double result = 0;
           
            if (Flour == "White" || Flour == "white")
            {
                flourModifier = 1.5;   
            }

            else if (Flour == "Wholegrain" || Flour == "wholegrain")
            {
                flourModifier = 1.0;
            }

            double bakingModifier = CheckBackingTechniqueType();
            result = (CALORIES * grams) * flourModifier * bakingModifier;

            return result;
        }

        private double CheckBackingTechniqueType()
        {
            double value = 0;

            if (this.BakingTechnique == "Chewy" || this.BakingTechnique == "chewy")
            {
                value = 1.1;
            }

            else if (this.BakingTechnique == "Crispy" || this.BakingTechnique == "crispy")
            {
                value = 0.9;
            }

            else if (this.BakingTechnique == "Homemade" || this.BakingTechnique == "homemade")
            {
                value = 1.0;
            }

            return value;
        }
    }
}
