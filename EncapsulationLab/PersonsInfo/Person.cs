using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace PersonsInfo
{
    public class Person
    {
        private String firstName;
        private String lastName;
        private int age;
        private decimal salary;

        public Person(string firstName, string lastName, int age, decimal salary)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Salary = salary;
        }

        public string FirstName 
        { 
            get 
            {
                return firstName;
            }
            private set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
                }

                firstName = value;
            }
        }
        public string LastName 
        {
            get
            {
                return lastName;
            }
            private set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
                }

                lastName = value;
            }
        }
        public int  Age 
        {
            get
            {
                return age;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Age cannot be zero or a negative integer!");
                }

                age = value;
            } 
        }
        public decimal Salary 
        { 
            get
            {
                return salary;
            }
            set
            {
                if (value < 460)
                {
                    throw new ArgumentException("Salary cannot be less than 460 leva!");
                }

                salary = value;
            }
        }

        public decimal IncreaseSalary(decimal percentage)
        {
            decimal increasing = percentage / 100 * Salary;           

            if (Age < 30)
            {
                increasing /= 2; 
            }

            Salary += increasing;

            return Salary;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} is {Age} years old.";
        }
    }
}
