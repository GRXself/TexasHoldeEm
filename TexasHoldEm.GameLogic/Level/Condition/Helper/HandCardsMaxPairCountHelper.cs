using System.Collections.Generic;
using System.Linq;
using TexasHoldEm.GameLogic.Models;

namespace TexasHoldEm.GameLogic.Level.Condition.Helper
{
    public static class HandCardsMaxPairCountHelper
    {
        public static int GetHandCardsMaxPairCount(List<PokerCard> cards)
        {
            return GetPairCount(cards);
        }

        private static int GetPairCount(List<PokerCard> cards)
        {
            return cards.Count(c1 => cards.Count(c2 => c1.CompareTo(c2).Equals(0)).Equals(2)) / 2;
        }
    }
}