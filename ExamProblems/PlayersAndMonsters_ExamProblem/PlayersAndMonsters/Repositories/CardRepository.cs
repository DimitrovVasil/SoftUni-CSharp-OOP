using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayersAndMonsters.Repositories
{
    public class CardRepository : ICardRepository
    {
        private List<ICard> cards;

        public CardRepository()
        {
            cards = new List<ICard>();
        }

        public int Count => this.cards.Count;

        public IReadOnlyCollection<ICard> Cards => cards.AsReadOnly();

        public void Add(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException("Card cannot be null!");
            }

            if (cards.Any(p => p.Name == card.Name))
            {
                throw new ArgumentException($"Card {card.Name} already exists!");
            }

            cards.Add(card);
        }

        public ICard Find(string name)
        {
            var targetCard = cards.FirstOrDefault(c => c.Name == name);

            //TODO: Must check if card is null?
            return targetCard;
        }

        public bool Remove(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException("Card cannot be null!");
            }

            return cards.Remove(card);
        }
    }
}
