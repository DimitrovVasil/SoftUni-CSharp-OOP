using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage.Contracts
{
    public interface IBuyer
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public int Food { get; set; }

        public int BuyFood();
    }
}
