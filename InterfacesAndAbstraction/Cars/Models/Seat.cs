using System;
using System.Collections.Generic;
using System.Text;

namespace Cars.Models
{
    public class Seat : ICar
    {
        public Seat(string model, string color)
        {
            Model = model;
            Color = color;
        }

        public string Model { get; set; }
        public string Color { get; set; }

        public void Start()
        {
            Console.WriteLine("Engine start");
        }

        public void Stop()
        {
            Console.WriteLine("Breaaak!");
        }

        public override string ToString()
        {
            return $"{Color} {this.GetType().Name} {Model}";
        }
    }
}
