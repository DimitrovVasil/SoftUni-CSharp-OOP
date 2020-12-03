using CounterStrike.Models.Players.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CounterStrike.Models.Maps.Contracts
{
    public class Map : IMap
    {
        public string Start(ICollection<IPlayer> players)
        {
            var terrorists = players.Where(p => players.GetType().Name == nameof(Terrorist)).ToList();
            var counterTerrorists = players.Where(p => players.GetType().Name == nameof(CounterTerrorist)).ToList();

            while (terrorists.Any(p => p.IsAlive) || counterTerrorists.Any(p => p.IsAlive))
            {
                foreach (var terrorist in terrorists)
                {
                    if (terrorist.IsAlive)
                    {
                        foreach (var counterTerrorist in counterTerrorists)
                        {
                            var bulletFired = terrorist.Gun.Fire();
                            counterTerrorist.TakeDamage(bulletFired);
                        }
                    }
                }

                if (!counterTerrorists.Any(p => p.IsAlive))
                {
                    break;
                }

                foreach (var counterTerrorist in counterTerrorists)
                {
                    if (counterTerrorist.IsAlive)
                    {
                        foreach (var terrorist in terrorists)
                        {
                            var bulletFired = counterTerrorist.Gun.Fire();
                            terrorist.TakeDamage(bulletFired);
                        }
                    }
                }
            }

            if (!counterTerrorists.Any(p => p.IsAlive))
            {
                return $"Terrorist wins!";
            }

            else
            {
                return $"Counter Terrorist wins!";
            }

        }
    }
}
