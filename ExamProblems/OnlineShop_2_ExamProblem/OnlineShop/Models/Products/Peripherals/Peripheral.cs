using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Models.Products.Peripherals
{
    public class Peripheral : Product
    {
        public Peripheral(int id, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            ConnectionType = connectionType;
        }

        public string ConnectionType { get; set; }

        public override string ToString()
        {
            return base.ToString() + $" Connection Type: {ConnectionType}";
        }
    }
}
