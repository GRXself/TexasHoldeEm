using System.Collections.Generic;
using TexasHoldEm.GameLogic.Level;
using TexasHoldEm.GameLogic.Models;

namespace TexasHoldEm.GameLogic.Tests.Level
{
    public abstract class TexasLevelTestsBase
    {
        protected readonly TexasHoldEmHandCardLevel CurrentLevel;

        protected TexasLevelTestsBase(TexasHoldEmHandCardLevel currentLevel)
        {
            CurrentLevel = currentLevel;
        }

        protected static List<PokerCard> CreateHandCardsByCardsString(string cardsString)
        {
            return new HandCards(cardsString).Cards;
        }
        
        protected static TexasHoldEmPlayer CreateBlackPlayer(string cardsString)
        {
            return CreatePlayer("Black", cardsString);
        }

        protected static TexasHoldEmPlayer CreateWhitePlayer(string cardsString)
        {
            return CreatePlayer("White", cardsString);
        }

        private static TexasHoldEmPlayer CreatePlayer(string playerName, string cardsString)
        {
            return new TexasHoldEmPlayer(playerName) 
            {
                HandCards = new HandCards(cardsString),
            };
        }
    }
}