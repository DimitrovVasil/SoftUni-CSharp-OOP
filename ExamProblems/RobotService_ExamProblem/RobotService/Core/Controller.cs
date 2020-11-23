using RobotService.Core.Contracts;
using RobotService.Models.Garages;
using RobotService.Models.Procedures;
using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private Garage garage;
        private Chip chip;
        private TechCheck techCheck;
        private Rest rest;
        private Work work;
        private Charge charge;
        private Polish polish;

        public Controller()
        {
            garage = new Garage();
            chip = new Chip();
            techCheck = new TechCheck();
            rest = new Rest();
            work = new Work();
            charge =  new Charge();
            polish = new Polish();
        }  

        public string Charge(string robotName, int procedureTime)
        {
            if (!garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InexistingRobot, robotName));
            }

            charge.DoService(garage.Robots[robotName], procedureTime);
            charge.Robots.Add(garage.Robots[robotName]);

            return $"{string.Format(OutputMessages.ChargeProcedure, robotName)}";
        }

        public string Chip(string robotName, int procedureTime)
        {
            if (!garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InexistingRobot, robotName));
            }
    
            chip.DoService(garage.Robots[robotName], procedureTime);
            chip.Robots.Add(garage.Robots[robotName]);

            return $"{string.Format(OutputMessages.ChipProcedure, robotName)}";
        }

        public string History(string procedureType)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(procedureType);


            if (procedureType == "Charge")
            {
                foreach (var robot in charge.Robots)
                {
                    sb.AppendLine(robot.ToString());
                }
   
            }

            else if (procedureType == "Chip")
            {
                foreach (var robot in chip.Robots)
                {
                    sb.AppendLine(robot.ToString());
                }     
            }

            else if (procedureType == "Polish")
            {
                foreach (var robot in polish.Robots)
                {
                    sb.AppendLine(robot.ToString());
                }  
            }

            else if (procedureType == "Rest")
            {
                foreach (var robot in rest.Robots)
                {
                    sb.AppendLine(robot.ToString());
                }    
            }

            else if (procedureType == "TechCheck")
            {
                foreach (var robot in techCheck.Robots)
                {
                    sb.AppendLine(robot.ToString());
                }
            }

            else if (procedureType == "Work")
            {
                foreach (var robot in work.Robots)
                {
                    sb.AppendLine(robot.ToString());
                }     
            }

            string result = sb.ToString().TrimEnd();

            return result;
        }

        public string Manufacture(string robotType, string name, int energy, int happiness, int procedureTime)
        {
            if (robotType != "PetRobot" && robotType != "HouseholdRobot" && robotType != "WalkerRobot")
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidRobotType, robotType));
            }

            if (energy < 0 || energy > 100)
            {
                throw new ArgumentException(ExceptionMessages.InvalidEnergy);
            }

            if (happiness < 0 || happiness > 100)
            {
                throw new ArgumentException(ExceptionMessages.InvalidHappiness);
            }

            if (garage.Robots.Count == 10)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }

            if (garage.Robots.ContainsKey(name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingRobot, name));
            }

            IRobot robot = null;

        
            if (robotType == "PetRobot")
            {
                robot = new PetRobot(name, energy, happiness, procedureTime);
            }

            else if (robotType == "HouseholdRobot")
            {
                robot = new HouseholdRobot(name, energy, happiness, procedureTime);
            }

            else if (robotType == "WalkerRobot")
            {
                robot = new WalkerRobot(name, energy, happiness, procedureTime);
            }

            garage.Manufacture(robot);
            
            return $"{String.Format(OutputMessages.RobotManufactured, name)}";
        }

        public string Polish(string robotName, int procedureTime)
        {
            if (!garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InexistingRobot, robotName));
            }

            polish.DoService(garage.Robots[robotName], procedureTime);
            polish.Robots.Add(garage.Robots[robotName]);

            return $"{string.Format(OutputMessages.PolishProcedure, robotName)}";
        }

        public string Rest(string robotName, int procedureTime)
        {
            if (!garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InexistingRobot, robotName));
            }

            rest.DoService(garage.Robots[robotName], procedureTime);
            rest.Robots.Add(garage.Robots[robotName]);

            return $"{string.Format(OutputMessages.RestProcedure, robotName)}";
        }

        public string Sell(string robotName, string ownerName)
        {
            if (!garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InexistingRobot, robotName));
            }

            var robotForSell = garage.Robots[robotName];

            robotForSell.IsBought = true;

            if (robotForSell.IsChipped)
            {
                return $"{string.Format(OutputMessages.SellChippedRobot, ownerName)}";
            }

            else
            {
                return $"{string.Format(OutputMessages.SellNotChippedRobot, ownerName)}";
            }
        }

        public string TechCheck(string robotName, int procedureTime)
        {
            if (!garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InexistingRobot, robotName));
            }

            techCheck.DoService(garage.Robots[robotName], procedureTime);
            techCheck.Robots.Add(garage.Robots[robotName]);

            return $"{string.Format(OutputMessages.TechCheckProcedure, robotName)}";
        }

        public string Work(string robotName, int procedureTime)
        {
            if (!garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InexistingRobot, robotName));
            }

            work.DoService(garage.Robots[robotName], procedureTime);
            work.Robots.Add(garage.Robots[robotName]);

            return $"{string.Format(OutputMessages.WorkProcedure, robotName, procedureTime)}";
        }
    }
}
