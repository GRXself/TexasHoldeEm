using System.Collections.Generic;
using System.Linq;
using TexasHoldEm.GameLogic.Level;

namespace TexasHoldEm.GameLogic.Models
{
    public class HandCards
    {
        public readonly List<PokerCard> Cards = new List<PokerCard>();

        public HandCards(string inputString)
        {
            var sourceCardStrings = inputString.Trim().Split(" ");
            foreach (var singleCardString in sourceCardStrings)
            {
                Cards.Add(new PokerCard(singleCardString));
            }

            Cards = Cards.OrderBy(c => c.Value).ToList();
        }

        public HandCards(List<PokerCard> cards)
        {
            Cards = cards;
        }

        public TexasHoldEmHandCardLevel GetHandCardsLevel()
        {
            return TexasHoldEmHandCardLevel.GetAllLevelInstances()
                .FirstOrDefault(currentLevel => currentLevel.IsThisLevel(Cards));
        }

        public override string ToString()
        {
            var s = "";
            Cards.ForEach(c => s += c.ToString() + " ");
            return s.Trim();
        }
    }
}