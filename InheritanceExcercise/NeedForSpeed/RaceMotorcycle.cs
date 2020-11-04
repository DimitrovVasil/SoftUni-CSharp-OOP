using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class RaceMotorcycle : Motorcycle
    {
        public RaceMotorcycle(int horsePower, double fuel) : base(horsePower, fuel)
        {
        }

        public override double DefaultFuelConsumption
        {
            get
            {
                return 8;
            }

            set
            {
                DefaultFuelConsumption = 8;
            }
        }
    }
}
