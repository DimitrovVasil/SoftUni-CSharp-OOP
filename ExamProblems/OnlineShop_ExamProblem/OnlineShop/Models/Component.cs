using OnlineShop.Models.Products.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Models
{
    public abstract class Component :  Product, IComponent
    {
        private int generation;

        public Component(int id, string manufacturer, string model, decimal price, double overallPerformance, int generation) 
            : base(id, manufacturer, model, price, overallPerformance)
        {
            Generation = generation;
        }

        public int Generation
        {
            get
            {
                return generation;
            }

            set
            {
                generation = value;
            }
        }

        public override string ToString()
        {
            return $"{base.ToString()} Generation: {Generation}";
        }
    }
}
