using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class StationaryPhone : IPhone
    {
        public string Model { get; set; }

        public string Call(string number)
        {
            if (IsValidNumber(number))
            {
                return $"Dialing... {number}";
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
