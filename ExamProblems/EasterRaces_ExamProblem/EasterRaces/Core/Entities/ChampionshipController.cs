using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Entities;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private CarRepository carRepository;
        private RaceRepository raceRepository;
        private DriverRepository driverRepository;

        public ChampionshipController()
        {
            carRepository = new CarRepository();
            raceRepository = new RaceRepository();
            driverRepository = new DriverRepository();
        }

        public string AddCarToDriver(string driverName, string carModel)
        {
            if (!driverRepository.Models.Any(d => d.Name == driverName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            if (!carRepository.Models.Any(c => c.Model == carModel))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarNotFound, carModel));
            }

            IDriver targetDriver = driverRepository.GetByName(driverName);
            ICar targetCar = carRepository.GetByName(carModel);

            targetDriver.AddCar(targetCar);

            return $"{string.Format(OutputMessages.CarAdded, driverName, carModel)}";
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            IRace raceResult = raceRepository.GetByName(raceName);
            IDriver driverResult = driverRepository.GetByName(driverName);

            if (raceResult == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            if (driverResult == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            raceResult.AddDriver(driverResult);

            return $"{string.Format(OutputMessages.DriverAdded, driverName, raceName)}";
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            if (carRepository.Models.Any(c=> c.Model == model))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CarExists, model));
            }

            ICar car = null;

            if (type == "Muscle")
            {
                car = new MuscleCar(model, horsePower);
            }

            else if (type == "Sports")
            {
                car = new SportsCar(model, horsePower);
            }

            carRepository.Add(car);

            return $"{string.Format(OutputMessages.CarCreated, car.GetType().Name, model)}";
        
        }

        public string CreateDriver(string driverName)
        {  
            if (driverRepository.Models.Any(d=> d.Name == driverName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriversExists, driverName));
            }

            IDriver driver = new Driver(driverName);
            driverRepository.Add(driver);

            return $"{string.Format(OutputMessages.DriverCreated, driverName)}";
        }

        public string CreateRace(string name, int laps)
        {
            IRace raceResult = raceRepository.GetByName(name);

            if (raceResult != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, name));
            }

            raceResult = new Race(name, laps);
            raceRepository.Add(raceResult);

            return $"{string.Format(OutputMessages.RaceCreated, name)}";
        }

        public string StartRace(string raceName)
        {
            IRace raceResult = raceRepository.GetByName(raceName);

            if (raceResult == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            if (raceResult.Drivers.Count < 3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid, raceName, 3));
            }

            var sortedDrivers = raceResult.Drivers.OrderByDescending(d => d.Car.CalculateRacePoints(raceResult.Laps)).ToList();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Driver {sortedDrivers[0].Name} wins {raceName} race.");
            sb.AppendLine($"Driver {sortedDrivers[1].Name} is second in {raceName} race.");
            sb.AppendLine($"Driver {sortedDrivers[2].Name} is third in {raceName} race.");

            string sbAsStr = sb.ToString().TrimEnd();

            return sbAsStr;
        }
    }
}
