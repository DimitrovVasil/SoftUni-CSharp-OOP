using EasterRaces.Core.Contracts;
using EasterRaces.IO;
using EasterRaces.IO.Contracts;
using EasterRaces.Core.Entities;
using EasterRaces.Repositories.Entities;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Repositories.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Entities;

namespace EasterRaces
{
    public class StartUp
    {
        public static void Main()
        {
            IChampionshipController controller = null; //new ChampionshipController();
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            Engine enigne = new Engine(controller, reader, writer);
            enigne.Run();

           //DriverRepository cars = new DriverRepository();
            //System.Console.WriteLine(cars.GetType().Name);
        }
    }
}
