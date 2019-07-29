using System.Collections.Generic;
using TexasHoldEm.GameLogic.Core;
using TexasHoldEm.GameLogic.Level.Comparer;
using TexasHoldEm.GameLogic.Level.Condition;
using TexasHoldEm.GameLogic.Models;

namespace TexasHoldEm.GameLogic.Level
{
    public class TwoPairsLevel : TexasHoldEmHandCardLevel
    {
        protected override void Initializer()
        {
            Name = "two pairs";
            Value = (int) TexasHoldEmHandCardLevelOrder.TwoPairs;
        }

        public override bool IsThisLevel(List<PokerCard> cards)
        {
            return new TwoPairsConditionChecker().IsThisCondition(cards);
        }

        public override TexasGameResult GetSameLevelCompareResult(
            TexasHoldEmPlayer blackPlayer,
            TexasHoldEmPlayer whitePlayer)
        {
            return new PairConditionComparer().GetCompareResult(blackPlayer, whitePlayer);
        }
    }
}