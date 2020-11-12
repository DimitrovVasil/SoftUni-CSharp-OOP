using System;
using System.Collections.Generic;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Utilities.Messages;

namespace EasterRaces.Models.Cars.Entities
{
    public class Car : ICar
    {
        private string model;
        private int horsePower;
        private int minHorsePower;
        private int maxHorsePower;

        public Car(string model, int horsePower, double cubicCentimeters, int minHorsePower, int maxHorsePower)
        {
            Model = model;
            HorsePower = horsePower;
            CubicCentimeters = cubicCentimeters;
            this.minHorsePower = minHorsePower;
            this.maxHorsePower = maxHorsePower;
        }

        public string Model
        { 
            get => this.model;
            private set 
            {
                if (String.IsNullOrWhiteSpace(value) || value.Length < 4)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidModel, value, 4));
                }

                this.model = value;
            }
        }
        public int HorsePower 
        {
            get => this.horsePower;
            private set 
            {
                if (value < minHorsePower || value > maxHorsePower)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidHorsePower, value));
                }

                horsePower = value;
            }
        }
        public double CubicCentimeters { get; private set; }
       

        public double CalculateRacePoints(int laps)
        {
            return CubicCentimeters / horsePower * laps;
        }
    }

}
