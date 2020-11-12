using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;

namespace OnlineShop.Models
{
   
    public abstract class Computer : Product, IComputer
    {
        private ICollection<IComponent> components;
        private ICollection<IPeripheral> peripherals;

        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance) 
            : base(id, manufacturer, model, price, overallPerformance)
        {
            components = new List<IComponent>();
            peripherals = new List<IPeripheral>();
        }

        public IReadOnlyCollection<IComponent> Components 
        {
            get
            {
                return this.components.ToList().AsReadOnly();
            }
        }

        public IReadOnlyCollection<IPeripheral> Peripherals
        {
            get
            {
                return (IReadOnlyCollection<IPeripheral>)peripherals.ToList().AsReadOnly();
            }
        }

        public override double OverallPerformance
        {
            get
            {
                if (this.Components.Count == 0)
                {
                    return base.OverallPerformance;
                }

                else
                {
                    return base.OverallPerformance + components.Average(x => x.OverallPerformance);
                }
            }
        }

        public override decimal Price 
        {
            get => base.Price + this.peripherals.Sum(x => x.Price) + this.components.Sum(x => x.Price); 
            
        }

        public void AddComponent(IComponent component)
        {
            if (Components.Contains(component))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingComponent, component.GetType().Name, this.GetType().Name, this.Id));
            }

            components.Add(component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (Peripherals.Contains(peripheral))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingPeripheral, peripheral.GetType().Name, this.GetType().Name, this.Id));
            }

            peripherals.Add(peripheral);
        }

        public IComponent RemoveComponent(string componentType)
        {
            if (Components.Count == 0 || !Components.Any(x => x.GetType().Name == componentType))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingComponent, componentType, this.GetType().Name, this.Id));
            }

            IComponent componentForRemove = Components.FirstOrDefault(x => x.GetType().Name == componentType);
            components.Remove(componentForRemove);

            return componentForRemove;
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {   

            if (Peripherals.Count == 0 || !Peripherals.Any(x => x.GetType().Name == peripheralType))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingPeripheral, peripheralType, this.GetType().Name, this.Id));
            }

            IPeripheral peripheralForRemove = Peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType);
            peripherals.Remove(peripheralForRemove);

            return peripheralForRemove;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($" Components ({Components.Count}):");

            foreach (var component in Components)
            {
                sb.AppendLine("  " + component.ToString());
            }

            sb.AppendLine($" Peripherals ({Peripherals.Count}); Average Overall Performance ({Peripherals.Average(x => x.OverallPerformance)}):");

            foreach (var peripheral in Peripherals)
            {
                sb.AppendLine("  " + peripheral.ToString());
            }

            return sb.ToString().TrimEnd();
        }

    }
}