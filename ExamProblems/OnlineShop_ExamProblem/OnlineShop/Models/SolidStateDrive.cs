using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Models
{
    public class SolidStateDrive : Component
    {
        private const double Multiplier = 1.20;

        public SolidStateDrive(int id, string manufacturer, string model, decimal price, double overallPerformance, int generation) 
            : base(id, manufacturer, model, price, overallPerformance * Multiplier, generation)
        {
        }
    }
}
