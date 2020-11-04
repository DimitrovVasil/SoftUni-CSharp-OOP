using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl.Contracts
{
    public class Citizen : ICreature
    {
        public Citizen(string name, int age, string id)
        {
            Name = name;
            Age = age;
            Id = id;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Id { get ; set; }
    }
}
