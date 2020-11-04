using System;
using System.Collections.Generic;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Contracts;

namespace EasterRaces.Models.Drivers.Entities
{
    public class Driver : IDriver
    {
        private string name;
        private bool canParticipate;

        public Driver(string name)
        {
            Name = name;
            CanParticipate = false;
        }

        public string Name
        { 
            get
            {
                return name;
            }

            set
            {
                if (value == null || value == "" || value.Length < 5)
                {
                    throw new ArgumentException($"Name {value} cannot be less than 5 symbols.");
                }

                name = value;
            }
        }

        public ICar Car { get; set; }

        public int NumberOfWins { get; set; }

        public bool CanParticipate
        {
            get
            {
                return canParticipate;
            }
            set
            {
                if (this.Car == null)
                {
                    canParticipate = false;
                }

                canParticipate = true;
            }
        }

        public void AddCar(ICar car)
        {
            if (car == null)
            {
                throw new ArgumentException("Car cannot be null.");
            }

            Car = car;
            canParticipate = true;
        }

        public void WinRace()
        {
            NumberOfWins++;
        }
    }
}
