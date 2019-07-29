using System.Collections.Generic;
using TexasHoldEm.GameLogic.Core;
using TexasHoldEm.GameLogic.Level.Comparer;
using TexasHoldEm.GameLogic.Level.Condition;
using TexasHoldEm.GameLogic.Models;

namespace TexasHoldEm.GameLogic.Level
{
    public class FourOfAKindLevel : TexasHoldEmHandCardLevel
    {
        protected override void Initializer()
        {
            Name = "four of a kind";
            Value = (int) TexasHoldEmHandCardLevelOrder.FourOfAKind;
        }

        public override bool IsThisLevel(List<PokerCard> cards)
        {
            return new FourOfAKindConditionChecker().IsThisCondition(cards);
        }

        public override TexasGameResult GetSameLevelCompareResult(TexasHoldEmPlayer blackPlayer,
            TexasHoldEmPlayer whitePlayer)
        {
            return new MiddleCardConditionComparer().GetCompareResult(blackPlayer, whitePlayer);
        }
    }
}