using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telephony
{
    public class Smartphone : ISmartPhone
    {
        public string Model { get; set; }

        public string Browse(string url)
        {
            if (url.Any(x => Char.IsDigit(x)))
            {
                return $"Invalid URL!";
            }

            return $"Browsing: {url}!";
        }

        public string Call(string number)
        {
            if (IsValidNumber(number))
            {
                return $"Calling... {number}";
            }

            return "Invalid number!";
        }

        private bool IsValidNumber(string number)
        {
            bool isValid = true;

            for (int i = 0; i < number.Length; i++)
            {
                if (!Char.IsDigit(number[i]))
                {
                    isValid = false;
                }
            }

            return isValid;
        }
    }
}
