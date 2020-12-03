using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Repositories.Contracts;
using CounterStrike.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CounterStrike.Core.Contracts
{
    public class Controller : IController
    {
        private GunRepository gunRepository;
        private PlayerRepository playerRepository;
        private IMap map;

        public Controller()
        {
            gunRepository = new GunRepository();
            playerRepository = new PlayerRepository();
            map = new Map();
        }

        public string AddGun(string type, string name, int bulletsCount)
        {
            if (type != nameof(Pistol) && type != nameof(Rifle))
            {
                throw new ArgumentException(ExceptionMessages.InvalidGunType);
            }

            IGun gun = null;

            if (type == nameof(Pistol))
            {
                gun = new Pistol(name, bulletsCount);
            }

            else if (type == nameof(Rifle))
            {
                gun = new Rifle(name, bulletsCount);
            }

            gunRepository.Add(gun);
            return String.Format(OutputMessages.SuccessfullyAddedGun, name);
        }

        public string AddPlayer(string type, string username, int health, int armor, string gunName)
        {
            var targetGun = gunRepository.FindByName(gunName);

            if (targetGun == null)
            {
                throw new ArgumentException(ExceptionMessages.GunCannotBeFound);
            }

            if (type != nameof(Terrorist) && type != nameof(CounterTerrorist))
            {
                throw new ArgumentException(ExceptionMessages.InvalidPlayerType);
            }

            IPlayer player = null;
            

            if (type == nameof(Terrorist))
            {
                player = new Terrorist(username, health, armor, targetGun);
            }

            else if (type == nameof(CounterTerrorist))
            {
                player = new CounterTerrorist(username, health, armor, targetGun);
            }

            playerRepository.Add(player);
            return String.Format(OutputMessages.SuccessfullyAddedPlayer, username);
        }

        public string Report()
        {
           var orderedPlayers = playerRepository.Models
                .OrderBy(p => p.GetType().Name)
                .ThenByDescending(p => p.Health)
                .ThenBy(p => p.Username)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var player in orderedPlayers)
            {
                sb.AppendLine(player.ToString());
                Console.WriteLine();
            }

            string result = sb.ToString().TrimEnd();
            return result;
        }


        //TODO: is that method correct?
        public string StartGame()
        {
           var alivePlayers = playerRepository.Models.Where(p => p.IsAlive).ToList();
           string result = map.Start(alivePlayers);
           return result;
        }
    }
}
