using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CounterStrike.Models.Maps
{
    public class Map : IMap
    {
        public Map()
        {
        }

        public string Start(ICollection<IPlayer> players)
        {
            List<IPlayer> terrorists = players.Where(p => p.GetType().Name == typeof(Terrorist).Name).ToList();
            List<IPlayer> counterTerrorists = players.Where(p => p.GetType().Name == typeof(CounterTerrorist).Name).ToList();

            while (!terrorists.Any(x=>x.IsAlive) || !counterTerrorists.Any(x => x.IsAlive))
            {
                foreach (var terrorist in terrorists)
                {
                    if (terrorist.IsAlive)
                    {
                        foreach (var counterTerrorist in counterTerrorists)
                        {
                            var points = terrorist.Gun.Fire();
                            counterTerrorist.TakeDamage(points);
                        }
                    }
                }

                if (!counterTerrorists.Any(x => x.IsAlive))
                {
                    break;
                }

                foreach (var counterTerrorist in counterTerrorists)
                {
                    if (counterTerrorist.IsAlive)
                    {
                        foreach (var terrorist in terrorists)
                        {
                            var points = counterTerrorist.Gun.Fire();
                            terrorist.TakeDamage(points);
                        }
                    }
                }
            }

            if (!terrorists.Any(x=>x.IsAlive))
            {
                return "Counter Terrorist wins!";
            }

            return "Terrorist wins!";
        }
    }
}
