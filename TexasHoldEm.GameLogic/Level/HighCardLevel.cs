using System.Collections.Generic;
using TexasHoldEm.GameLogic.Core;
using TexasHoldEm.GameLogic.Level.Comparer;
using TexasHoldEm.GameLogic.Level.Condition;
using TexasHoldEm.GameLogic.Models;

namespace TexasHoldEm.GameLogic.Level
{
    public class HighCardLevel : TexasHoldEmHandCardLevel
    {
        protected override void Initializer()
        {
            Name = "high card";
            Value = (int) TexasHoldEmHandCardLevelOrder.HighCard;
        }

        public override bool IsThisLevel(List<PokerCard> cards)
        {
            return new HighCardConditionChecker().IsThisCondition(cards);
        }

        public override TexasGameResult GetSameLevelCompareResult(TexasHoldEmPlayer blackPlayer,
            TexasHoldEmPlayer whitePlayer)
        {
            return new HighCardConditionComparer().GetCompareResult(blackPlayer, whitePlayer);
        }
    }
}