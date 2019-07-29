using System.Collections.Generic;
using System.Linq;
using TexasHoldEm.GameLogic.Models;

namespace TexasHoldEm.GameLogic.Level.Condition.Helper
{
    public static class HandCardsMaxSameCountHelper
    {
        public static int GetHandCardsMaxSameCount(IReadOnlyList<PokerCard> cards)
        {
            return cards.Select(c1 => cards.Count(c2 => c2.CompareTo(c1).Equals(0)))
                .ToList()
                .Max();
        }
    }
}