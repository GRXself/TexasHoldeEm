using System.Collections.Generic;
using TexasHoldEm.GameLogic.Core;
using TexasHoldEm.GameLogic.Level.Comparer;
using TexasHoldEm.GameLogic.Level.Condition;
using TexasHoldEm.GameLogic.Models;

namespace TexasHoldEm.GameLogic.Level
{
    public class FullHouseLevel : TexasHoldEmHandCardLevel
    {
        protected override void Initializer()
        {
            Name = "full house";
            Value = (int) TexasHoldEmHandCardLevelOrder.FullHouse;
        }

        public override bool IsThisLevel(List<PokerCard> cards)
        {
            return new ThreeOfAKindConditionChecker().IsThisCondition(cards) &&
                   new OnePairConditionChecker().IsThisCondition(cards);
        }

        public override TexasGameResult GetSameLevelCompareResult(TexasHoldEmPlayer blackPlayer,
            TexasHoldEmPlayer whitePlayer)
        {
            return new MiddleCardConditionComparer().GetCompareResult(blackPlayer, whitePlayer);
        }
    }
}