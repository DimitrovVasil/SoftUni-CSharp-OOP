using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace AquaShop.Core.Contracts
{
   public class Controller : IController
    {
        private DecorationRepository decorations;
        private ICollection<IAquarium> aquariums;

        public Controller()
        {
            decorations = new DecorationRepository();
            aquariums = new List<IAquarium>();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            if (aquariumType != nameof(FreshwaterAquarium) && aquariumType != nameof(SaltwaterAquarium))
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }

            IAquarium aquarium = null;

            if (aquariumType == nameof(FreshwaterAquarium))
            {
                aquarium = new FreshwaterAquarium(aquariumName);
            }

            else if (aquariumType == nameof(SaltwaterAquarium))
            {
                aquarium = new SaltwaterAquarium(aquariumName);
            }

            aquariums.Add(aquarium);

            return string.Format(OutputMessages.SuccessfullyAdded, aquarium.GetType().Name);
        }

        public string AddDecoration(string decorationType)
        {
            if (decorationType != nameof(Plant) && decorationType != nameof(Ornament))
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }

            IDecoration decoration = null;

            if (decorationType == nameof(Plant))
            {
                decoration = new Plant();
            }

            else if (decorationType == nameof(Ornament))
            {
                decoration = new Ornament();
            }

            decorations.Add(decoration);

            return string.Format(OutputMessages.SuccessfullyAdded, decoration.GetType().Name);
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            if (fishType != nameof(FreshwaterFish) && fishType != nameof(SaltwaterFish))
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }

            IFish fish = null;

               var aquariumToCheck = aquariums.FirstOrDefault(x => x.Name == aquariumName);

          //TODO: Must check if aquarium is null??

                if (fishType == nameof(FreshwaterFish) && aquariumToCheck.GetType().Name == nameof(FreshwaterAquarium))
                {
                    fish = new FreshwaterFish(fishName, fishSpecies, price);
                    aquariumToCheck.AddFish(fish);
                    return string.Format(OutputMessages.EntityAddedToAquarium, fish.GetType().Name, aquariumName);
                }

                else if (fishType == nameof(SaltwaterFish) && aquariumToCheck.GetType().Name == nameof(SaltwaterFish))
                {
                    fish = new SaltwaterFish(fishName, fishSpecies, price);
                    aquariumToCheck.AddFish(fish);
                    return string.Format(OutputMessages.EntityAddedToAquarium, fish.GetType().Name, aquariumName);
                }

                else
                {
                    return OutputMessages.UnsuitableWater;
                }
        }

        public string CalculateValue(string aquariumName)
        {
            //TODO: aquairium is null?
            var aquariumToCheck = aquariums.FirstOrDefault(x => x.Name == aquariumName);

           decimal totalPrice = aquariumToCheck.Fish.Sum(x => x.Price) + aquariumToCheck.Decorations.Sum(x => x.Price);

            return String.Format(OutputMessages.AquariumValue, aquariumName, totalPrice);
        }

        public string FeedFish(string aquariumName)
        {
            //TODO: aquairium is null?
            var targetAquarium = aquariums.FirstOrDefault(x => x.Name == aquariumName);

            foreach (var fish in targetAquarium.Fish)
            {
                fish.Eat();
            }

            return String.Format(OutputMessages.FishFed, targetAquarium.Fish.Count);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            IDecoration decoration = decorations.FindByType(decorationType);

            if (decoration == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentDecoration, decorationType));
            }

            //TODO: must validate is aquarium null?
            IAquarium aquarium = aquariums.FirstOrDefault(x => x.Name == aquariumName);


            aquarium.AddDecoration(decoration);
            decorations.Remove(decoration);

            return string.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);
                 
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var aquarium in this.aquariums)
            {
                sb.AppendLine(aquarium.GetInfo());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
