using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        private const double Coffee_Milliliters = 50;
        private const decimal CoffeePrice = 3.50m;
        public Coffee(string name, double caffeine) : base(name, CoffeePrice, Coffee_Milliliters)
        {
            Caffeine = caffeine;
        }

        public double Caffeine { get; set; }
    }
}
