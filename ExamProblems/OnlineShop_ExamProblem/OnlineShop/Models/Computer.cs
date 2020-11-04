using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;

namespace OnlineShop.Models
{
    public abstract class Computer : Product
    {
        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            
        }

        private List<IComponent> components;
        private List<IPeripheral> peripherals;

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
                    //otherwise return the sum of the computer overall performance 
                    //and the average overall performance from all components
                    return this.overallPerformance + Components.Average(x => x.OverallPerformance);
                }
            } 
            
            set 
            {
                overallPerformance = value;
            } 
        }

        public override decimal Price 
        {
            get           
            {
                return this.price + Components.Sum(c => c.Price) + Peripherals.Sum(c => c.Price);
            }

            set
            {
                this.price = value;
            }
        }


        public void AddComponent(IComponent component)
        {
            //If the components collection contains a component with the same component type,
            //throw an ArgumentException
            //with the message "Component {component type} already exists in {computer type} with Id {id}."
            Type componentType = component.GetType();

            var searchedComponent = Components.FirstOrDefault(x => x.GetType() == componentType);

            if (searchedComponent != null)
            {
                // computer ID or component iD?
                throw new ArgumentException($"Component { component.GetType().Name } already exists in { this.GetType().Name} with Id {Id}.");
            }

            components.Add(component);
        }

        public IComponent RemoveComponent(string componentType)
        {
           // string componentTypeName = component.GetType();

            var componentForRemove = Components.FirstOrDefault(x => x.GetType().Name == componentType);

            if (Components.Count == 0 || componentForRemove == null)
            {
                throw new ArgumentException($"Component {componentType} does not exist in {this.GetType().Name} with Id {Id}.");
            }

            var removedItem = componentForRemove;
            components.Remove(componentForRemove);

            return removedItem;
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            Type peripheralType = peripheral.GetType();

            var searchedPeripheral = Peripherals.FirstOrDefault(x => x.GetType() == peripheralType);

            if (searchedPeripheral != null)
            {
                // computer ID or repirpheral iD?
                throw new ArgumentException($"Peripheral { peripheral.GetType().Name } already exists in { this.GetType().Name} with Id {Id}.");
            }

            peripherals.Add(peripheral);
        }

        IPeripheral RemovePeripheral(string peripheralType)
        {
            var peripheralForRemove = Peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType);

            if (Peripherals.Count == 0 || peripheralForRemove == null)
            {
                throw new ArgumentException($"Component {peripheralType} does not exist in {this.GetType().Name} with Id {Id}.");
            }

            var removedItem = peripheralForRemove;
            peripherals.Remove(peripheralForRemove);

            return removedItem;
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