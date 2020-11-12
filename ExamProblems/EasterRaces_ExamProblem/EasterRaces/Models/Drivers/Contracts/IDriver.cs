using EasterRaces.Models.Cars.Contracts;

namespace EasterRaces.Models.Drivers.Contracts
{
    public interface IDriver
    {
        public string Name { get; }
        public ICar Car { get;  }
        public int NumberOfWins { get; }
        public bool CanParticipate { get;  }
        public void AddCar(ICar Car);
        public void WinRace();
    }
}