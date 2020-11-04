using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public class MuscleCar : Car
    {
        public MuscleCar(string model, int horsePower) 
            : base(model, horsePower, 5000, 400, 600)
        {
        }

        public override int HorsePower
        {
            get
            {
                return this.HorsePower;
            }
            set
            {
                if (value < MinHorsePower || value > MaxHorsePower)
                {
                    throw new  ArgumentException($"Invalid horse power: {value}.");
                }

                HorsePower = value;
            }
        }

    }
}
