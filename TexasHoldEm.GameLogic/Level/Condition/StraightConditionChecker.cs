using System.Collections.Generic;
using System.Linq;
using TexasHoldEm.GameLogic.Models;

namespace TexasHoldEm.GameLogic.Level.Condition
{
    public class StraightConditionChecker : IHandCardsConditionChecker
    {
        public bool IsThisCondition(List<PokerCard> cards)
        {
            return cards.All(c => c.Value - cards.IndexOf(c) == cards.FirstOrDefault().Value);
        }
    }
}