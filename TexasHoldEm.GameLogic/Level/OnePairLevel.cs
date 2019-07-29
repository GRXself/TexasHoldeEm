using System.Collections.Generic;
using TexasHoldEm.GameLogic.Core;
using TexasHoldEm.GameLogic.Level.Comparer;
using TexasHoldEm.GameLogic.Level.Condition;
using TexasHoldEm.GameLogic.Models;

namespace TexasHoldEm.GameLogic.Level
{
    public class OnePairLevel : TexasHoldEmHandCardLevel
    {
        protected override void Initializer()
        {
            Name = "pair";
            Value = (int) TexasHoldEmHandCardLevelOrder.Pair;
        }

        public override bool IsThisLevel(List<PokerCard> cards)
        {
            return new OnePairConditionChecker().IsThisCondition(cards) &&
                   !new ThreeOfAKindConditionChecker().IsThisCondition(cards);
        }

        public override TexasGameResult GetSameLevelCompareResult(TexasHoldEmPlayer blackPlayer,
            TexasHoldEmPlayer whitePlayer)
        {
            return new PairConditionComparer().GetCompareResult(blackPlayer, whitePlayer);
        }
    }
}