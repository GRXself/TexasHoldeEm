using System.Collections.Generic;
using TexasHoldEm.GameLogic.Level.Condition.Helper;
using TexasHoldEm.GameLogic.Models;

namespace TexasHoldEm.GameLogic.Level.Condition
{
    public class OnePairConditionChecker : IHandCardsConditionChecker
    {
        public bool IsThisCondition(List<PokerCard> cards)
        {
            return HandCardsMaxPairCountHelper.GetHandCardsMaxPairCount(cards).Equals(1);
        }
    }
}