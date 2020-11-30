using OnlineShop.Common.Constants;
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
        private ICollection<IComputer> computers;
        private ICollection<IComponent> components;
        private ICollection<IPeripheral> peripherals;

        public Controller()
        {
            computers = new List<IComputer>();
            components = new List<IComponent>();
            peripherals = new List<IPeripheral>();
        }

        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            if (!IsComputerExist(id))
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            if (components.Any(c => c.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComponentId);
            }

            string[] availableComponentTypes = new string[] { "Motherboard", "PowerSupply", "RandomAccessMemory", "SolidStateDrive", "VideoCard", "CentralProcessingUnit" };

            if (!availableComponentTypes.Contains(componentType))
            {
                throw new ArgumentException(ExceptionMessages.InvalidComponentType);
            }

            IComponent component = null;  

            if (componentType == "Motherboard")
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

            else if (componentType == "CentralProcessingUnit")
            {
                component = new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation);
            }

            var targetComputer = computers.FirstOrDefault(c => c.Id == computerId);
            targetComputer.AddComponent(component);

            return $"{string.Format(SuccessMessages.AddedComponent, component.GetType().Name, id, targetComputer.Id)}";

        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            if (IsComputerExist(id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComputerId);
            }

            if (computerType != "Laptop" && computerType != "DesktopComputer")
            {
                throw new ArgumentException(ExceptionMessages.InvalidComputerType);
            }

            IComputer computer = null;

            if (computerType == "Laptop")
            {
                computer = new Laptop(id, manufacturer, model, price);
            }

            else if (computerType == "DesktopComputer")
            {
                computer = new DesktopComputer(id, manufacturer, model, price);
            }

            computers.Add(computer);

            return $"{string.Format(SuccessMessages.AddedComputer, id)}";
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            if (!IsComputerExist(computerId))
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            var targetComputer = computers.FirstOrDefault(c => c.Id == computerId);

            if (peripherals.Any(p=> p.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingPeripheralId);
            }

            IPeripheral peripheral = null;

            switch (peripheralType)
            {        
                case "Headset": peripheral = new Headset(id, manufacturer, model, price, overallPerformance, connectionType); break;
                case "Keyboard": peripheral = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType); break;
                case "Monitor": peripheral = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType); break;
                case "Mouse": new Mouse(id, manufacturer, model, price, overallPerformance, connectionType); break;
                default: throw new ArgumentException(ExceptionMessages.InvalidPeripheralType);
            }

            targetComputer.AddPeripheral(peripheral);
            peripherals.Add(peripheral);

            return $"{string.Format(SuccessMessages.AddedPeripheral, peripheral.GetType().Name, peripheral.Id, targetComputer.Id)}";
        }

        public string BuyBest(decimal budget)
        {
            var sortedComputers = computers.OrderByDescending(p => p.OverallPerformance);
            var targetComputer = sortedComputers.FirstOrDefault(p => p.Price <= budget);

            if (targetComputer != null)
            {
                computers.Remove(targetComputer);
                return targetComputer.ToString();
            }

            throw new ArgumentException(string.Format(ExceptionMessages.CanNotBuyComputer, budget));
        }

        public string BuyComputer(int id)
        {
            if (!IsComputerExist(id))
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            var targetComputer = computers.FirstOrDefault(c => c.Id == id);

            computers.Remove(targetComputer);
            return targetComputer.ToString();
        }

        public string GetComputerData(int id)
        {
            if (!IsComputerExist(id))
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            var targetComputer = computers.FirstOrDefault(c => c.Id == id);

            return targetComputer.ToString();
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            if (!IsComputerExist(computerId))
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            var targetComponent = components.FirstOrDefault(c => c.GetType().Name == componentType);
            var targetComputer = computers.FirstOrDefault(c => c.Id == computerId);

            targetComputer.RemoveComponent(componentType);
            components.Remove(targetComponent);

            return $"{string.Format(SuccessMessages.RemovedComponent, componentType, targetComponent.Id)}";
            
            //Component {0} does not exist in {1} with Id {2}.";
            //TODO:
            //throw new ArgumentException(string.Format(ExceptionMessages.NotExistingComponent, componentType, targetComputer.GetType().Name, targetComputer.Id));
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            if (!IsComputerExist(computerId))
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            var targetPeripheral = peripherals.FirstOrDefault(c => c.GetType().Name == peripheralType);
            var targetComputer = computers.FirstOrDefault(c => c.Id == computerId);

            targetComputer.RemoveComponent(peripheralType);
            peripherals.Remove(targetPeripheral);

            return $"{string.Format(SuccessMessages.RemovedPeripheral, targetPeripheral.GetType().Name, targetPeripheral.Id)}";
        }

        private bool IsComputerExist(int id)
        {
            if (computers.Any(computer => computer.Id == id))
            {
                return true;
            }

            return false;
        }
    }
}
