using System.Collections.Generic;
using TexasHoldEm.GameLogic.Level.Condition.Helper;
using TexasHoldEm.GameLogic.Models;

namespace TexasHoldEm.GameLogic.Level.Condition
{
    public class ThreeOfAKindConditionChecker : IHandCardsConditionChecker
    {
        public bool IsThisCondition(List<PokerCard> cards)
        {
            return HandCardsMaxSameCountHelper.GetHandCardsMaxSameCount(cards).Equals(3);
        }
    }
}