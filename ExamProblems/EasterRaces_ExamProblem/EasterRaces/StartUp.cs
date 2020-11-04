using EasterRaces.Core.Contracts;
using EasterRaces.IO;
using EasterRaces.IO.Contracts;
using EasterRaces.Core.Entities;
using EasterRaces.Repositories.Entities;

namespace EasterRaces
{
    public class StartUp
    {
        public static void Main()
        {
           // CarRepository<string> repo = new CarRepository<string>();

            IChampionshipController controller = null; //new ChampionshipController();
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            Engine enigne = new Engine(controller, reader, writer);
            enigne.Run();
        }
    }
}
