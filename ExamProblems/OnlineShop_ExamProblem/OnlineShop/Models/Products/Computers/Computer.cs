using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private List<IComponent> components;
        private List<IPeripheral> peripherals;

        public Computer(int id, string manufacturer, string model, decimal price, double overallPerformance) 
            : base(id, manufacturer, model, price, overallPerformance)
        {
            components = new List<IComponent>();
            peripherals = new List<IPeripheral>();
        }

        public IReadOnlyCollection<IComponent> Components => components.AsReadOnly();

        public IReadOnlyCollection<IPeripheral> Peripherals => peripherals.AsReadOnly();

        public override double OverallPerformance 
        {
            get
            {
                if (Components.Count == 0)
                {
                    return this.overallPerformance;
                }
                else
                {
                    return this.overallPerformance + Components.Sum(c => c.OverallPerformance);
                }
            } 

            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidOverallPerformance);
                }

                overallPerformance = value;

            }
        }

        public override decimal Price 
        {
            get => this.price + Components.Sum(x=>x.Price) + Peripherals.Sum(x => x.Price);
            protected set
            {

                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPrice);
                }

                price = value;
            }
        }

        public void AddComponent(IComponent component)
        {
            if (Components.Any(c => c.GetType().Name == component.GetType().Name))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.ExistingComponent, component.GetType().Name, this.GetType().Name, this.Id));
            }

            components.Add(component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (peripherals.Any(x=>x.GetType().Name == peripheral.GetType().Name))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.ExistingPeripheral, peripheral.GetType().Name, this.GetType().Name, this.Id));
            }

            peripherals.Add(peripheral);
        }

        public IComponent RemoveComponent(string componentType)
        {
            if (Components.Count == 0 || !Components.Any(c=>c.GetType().Name == componentType))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.NotExistingComponent, componentType, this.GetType().Name, this.Id));
            }

            var targetComponent = components.FirstOrDefault(x => x.GetType().Name == componentType);
            components.Remove(targetComponent);

            return targetComponent;
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            if (Peripherals.Count == 0 || !Peripherals.Any(c => c.GetType().Name == peripheralType))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.NotExistingPeripheral, peripheralType, this.GetType().Name, this.Id));
            }

            IPeripheral targetPeripheral = peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType);
            peripherals.Remove(targetPeripheral);

            return targetPeripheral;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(base.ToString());
            sb.AppendLine($" Components ({Components.Count}):");

            foreach (var component in Components)
            {
                sb.AppendLine($"  {component.ToString()}");
            }

            sb.AppendLine($" Peripherals ({Peripherals.Count}); Average Overall Performance ({Peripherals.Average(p => p.OverallPerformance)}):");

            foreach (var peripheral in Peripherals)
            {
                sb.AppendLine($"  {peripheral.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
