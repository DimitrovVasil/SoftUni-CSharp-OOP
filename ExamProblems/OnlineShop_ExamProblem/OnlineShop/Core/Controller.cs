using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private List<IComputer> computers;
        private List<IComponent> components;
        private List<IPeripheral> peripherals;
        public Controller()
        {
            computers = new List<IComputer>();
            components = new List<IComponent>();
            peripherals = new List<IPeripheral>();
        }
        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            if (!IsComputerExist(computerId))
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }

            if (components.Any(x => x.Id == id))
            {
                throw new ArgumentException("Component with this id already exists.");
            }

            IComponent component = null;

            if (componentType == "CentralProcessingUnit")
            {
                component = new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation);
            }

            else if (componentType == "Motherboard")
            {
                component = new Motherboard(id, manufacturer, model, price, overallPerformance, generation);
            }

            else if (componentType == "PowerSupply")
            {
                component = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
            }

            else if (componentType == "RandomAccessMemory")
            {
                component = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);
            }

            else if (componentType == "SolidStateDrive")
            {
                component = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
            }

            else if (componentType == "VideoCard")
            {
                component = new VideoCard(id, manufacturer, model, price, overallPerformance, generation);
            }

            else
            {
                throw new ArgumentException("Component type is invalid.");
            }

            var computer = computers.FirstOrDefault(c => c.Id == computerId);
            computer.AddComponent(component);
            components.Add(component);

            return $"Component {component.GetType().Name} with id {component.Id} added successfully in computer with id {computer.Id}.";
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            if (IsComputerExist(id))
            {
                throw new ArgumentException("Computer with this id already exists.");
            }

            IComputer computer = null;

            if (computerType == "DesktopComputer")
            {
                computer = new DesktopComputer(id, manufacturer, model, price);
            }

            else if (computerType == "Laptop")
            {
                computer = new Laptop(id, manufacturer, model, price);
            }

            else
            {
                throw new ArgumentException("Computer type is invalid.");
            }

            computers.Add(computer);
            return $"Computer with id {computer.Id} added successfully.";
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            if (!IsComputerExist(computerId))
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }

            if (peripherals.Any(x => x.Id == id))
            {
                throw new ArgumentException("Peripheral with this id already exists.");
            }

            IPeripheral peripheral = null;

            if (peripheralType == "Headset")
            {
                peripheral = new Headset(id, manufacturer, model, price, overallPerformance, connectionType);
            }

            else if (peripheralType == "Keyboard")
            {
                peripheral = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
            }

            else if (peripheralType == "Monitor")
            {
                peripheral = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
            }

            else if (peripheralType == "Mouse")
            {
                peripheral = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
            }

            else
            {
                throw new ArgumentException("Peripheral type is invalid.");
            }

            var computer = computers.FirstOrDefault(c => c.Id == computerId);
            computer.AddPeripheral(peripheral);
            peripherals.Add(peripheral);

            return $"Peripheral {peripheral.GetType().Name} with id {peripheral.Id} added successfully in computer with id {computer.Id}.";
        }

        public string BuyBest(decimal budget)
        {
            var computersByPrice = computers.Where(p => p.Price <= budget)
                .OrderByDescending(x=>x.OverallPerformance)
                .ToList();

            if (computersByPrice.Count == 0)
            {
                throw new ArgumentException($" Can't buy a computer with a budget of ${budget}.");
            }

            IComputer bestComputer = computersByPrice[0];
            computers.Remove(bestComputer);

            return bestComputer.ToString();
        }

        public string BuyComputer(int id)
        {
            if(!IsComputerExist(id))
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }


            var computer = computers.FirstOrDefault(x => x.Id == id);

            computers.Remove(computer);

            return computer.ToString();
        }

        public string GetComputerData(int id)
        {
            if (!IsComputerExist(id))
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }

            var computer = computers.FirstOrDefault(x => x.Id == id);

            return computer.ToString();
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            if (!IsComputerExist(computerId))
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }

            var computer = computers.FirstOrDefault(c => c.Id == computerId);

           IComponent component = computer.RemoveComponent(componentType);
            components.Remove(component);

            return $"Successfully removed {component.GetType().Name} with id {component.Id}.";
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            if (!IsComputerExist(computerId))
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }

            var computer = computers.FirstOrDefault(c => c.Id == computerId);

            IPeripheral peripheral = computer.RemovePeripheral(peripheralType);
            peripherals.Remove(peripheral);

            return $"Successfully removed {peripheral.GetType().Name} with id {peripheral.Id}.";
        }

        private bool IsComputerExist(int id)
        {
            if (computers.Any(c=>c.Id == id))
            {
                return true;
            }

            return false;
        }
    }
}
