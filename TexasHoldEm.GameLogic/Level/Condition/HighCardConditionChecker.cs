using System.Collections.Generic;
using TexasHoldEm.GameLogic.Level.Condition.Helper;
using TexasHoldEm.GameLogic.Models;

namespace TexasHoldEm.GameLogic.Level.Condition
{
    public class HighCardConditionChecker : IHandCardsConditionChecker
    {
        public bool IsThisCondition(List<PokerCard> cards)
        {
            return !new StraightConditionChecker().IsThisCondition(cards) &&
                   !new SameColorConditionChecker().IsThisCondition(cards) &&
                   HandCardsMaxSameCountHelper.GetHandCardsMaxSameCount(cards).Equals(1);
        }
    }
}