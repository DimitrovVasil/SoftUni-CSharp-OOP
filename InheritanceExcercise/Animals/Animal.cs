using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Animal
    {
        private int age;
        private string gender;

        public Animal(string name, int age, string gender)
        {
            Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name { get; set; }
        public int Age 
        {
            get
            { 
                return age; 
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid input");
                }

                age = value;
            }
            
        }
        public string Gender 
        {
            get
            {
                return gender;
            } 
            set
            {
                if (value != "Male" && value != "Female")
                {
                    throw new ArgumentException("Invalid input");
                }

                gender = value;
            }
        }

        public virtual string ProduceSound()
        {
            return "Producing sound";
        }

        public override string ToString()
        {
            return $"{Name} {Age} {Gender}";
        }
    }
}
