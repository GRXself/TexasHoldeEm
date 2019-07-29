using System.Collections.Generic;
using TexasHoldEm.GameLogic.Models;

namespace TexasHoldEm.GameLogic.Level.Condition
{
    public interface IHandCardsConditionChecker
    {
        bool IsThisCondition(List<PokerCard> cards);
    }
}