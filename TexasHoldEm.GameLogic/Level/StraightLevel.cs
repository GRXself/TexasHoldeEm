using System.Collections.Generic;
using TexasHoldEm.GameLogic.Core;
using TexasHoldEm.GameLogic.Level.Comparer;
using TexasHoldEm.GameLogic.Level.Condition;
using TexasHoldEm.GameLogic.Models;

namespace TexasHoldEm.GameLogic.Level
{
    public class StraightLevel : TexasHoldEmHandCardLevel
    {
        protected override void Initializer()
        {
            Name = "straight";
            Value = (int) TexasHoldEmHandCardLevelOrder.Straight;
        }

        public override bool IsThisLevel(List<PokerCard> cards)
        {
            return !new SameColorConditionChecker().IsThisCondition(cards) &&
                   new StraightConditionChecker().IsThisCondition(cards);
        }

        public override TexasGameResult GetSameLevelCompareResult(TexasHoldEmPlayer blackPlayer,
            TexasHoldEmPlayer whitePlayer)
        {
            return new HighCardConditionComparer().GetCompareResult(blackPlayer, whitePlayer);
        }
    }
}