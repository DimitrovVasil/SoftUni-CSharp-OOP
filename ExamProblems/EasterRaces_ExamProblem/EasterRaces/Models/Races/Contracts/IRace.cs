using EasterRaces.Models.Drivers.Contracts;

namespace EasterRaces.Models.Races.Contracts
{
    using System.Collections.Generic;

    public interface IRace
    {
        public string Name { get; }
        public int Laps { get; }

        public void AddDriver(IDriver Driver);
    }
}