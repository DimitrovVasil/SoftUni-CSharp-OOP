namespace PlayersAndMonsters.Core
{
    using System;
    using System.Linq;
    using System.Text;
    using Contracts;
    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Models.BattleFields;
    using PlayersAndMonsters.Models.Cards;
    using PlayersAndMonsters.Models.Cards.Contracts;
    using PlayersAndMonsters.Models.Players;
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Repositories;
    using PlayersAndMonsters.Repositories.Contracts;

    public class ManagerController : IManagerController
    {
        private IPlayerRepository players;
        private ICardRepository cardRepository;

        public ManagerController()
        {
            players = new PlayerRepository();
            cardRepository = new CardRepository();
        }

        public string AddPlayer(string type, string username)
        {
            IPlayer player = null;    

            if (type == "Beginner")
            {
                player = new Beginner(cardRepository, username);
            }

            else if (type == "Advanced")
            {
                player = new Advanced(cardRepository, username);
            }

            players.Add(player);
            return $"{string.Format(ConstantMessages.SuccessfullyAddedPlayer, type, username)}";
        }

        public string AddCard(string type, string name)
        {
            ICard card = null;

            if (type == "MagicCard")
            {
                card = new MagicCard(name);
            }

            else if (type == "TrapCard")
            {
                card = new TrapCard(name);
            }

            cardRepository.Add(card);

            return $"{string.Format(ConstantMessages.SuccessfullyAddedCard, type, name)}";
        }

        public string AddPlayerCard(string username, string cardName)
        {
            var targetPlayer = players.Players.FirstOrDefault(p => p.Username == username);
            var targetCard = cardRepository.Cards.FirstOrDefault(c => c.Name == cardName);

            targetPlayer.CardRepository.Add(targetCard);

            return $"{string.Format(ConstantMessages.SuccessfullyAddedPlayerWithCards, cardName, username)}";
        }

        public string Fight(string attackUser, string enemyUser)
        {
            var attacker = players.Players.FirstOrDefault(p => p.Username == attackUser);
            var enemy = players.Players.FirstOrDefault(p => p.Username == enemyUser);

            BattleField battleField = new BattleField();
            battleField.Fight(attacker, enemy);

            return $"{string.Format(ConstantMessages.FightInfo, attackUser, enemyUser)}";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var player in players.Players)
            {
                sb.AppendLine(player.ToString());

                foreach (var card in player.CardRepository.Cards)
                {
                    sb.AppendLine(card.ToString());
                }

                sb.AppendLine("###");
            }

            var result = sb.ToString().TrimEnd();

            return result;
        }
    }
}
