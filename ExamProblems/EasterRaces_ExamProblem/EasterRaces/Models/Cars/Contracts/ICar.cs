namespace EasterRaces.Models.Cars.Contracts
{
    public interface ICar
    {
        public string Model { get;  }

        public int HorsePower { get;  }

        public double CubicCentimeters { get; }

        public double CalculateRacePoints(int laps);
    }
}
