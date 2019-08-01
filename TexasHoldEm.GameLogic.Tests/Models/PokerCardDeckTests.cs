using System.Collections.Generic;
using System.Linq;
using TexasHoldEm.GameLogic.Models;
using Xunit;

namespace TexasHoldEm.GameLogic.Tests.Models
{
    public class PokerCardDeckTests
    {
        private readonly PokerCardDeck _pokerCardDeck;

        public PokerCardDeckTests()
        {
            PokerCardDeck.RefreshInstance();
            _pokerCardDeck = PokerCardDeck.GetInstance();
        }

        [Fact]
        public void GetSingleCard_GetEveryCards_ReturnDifferentCard()
        {
            var pokerCards = new List<PokerCard>();
            const int maxDeckCount = 52;

            while (_pokerCardDeck.HasNextCard())
            {
                pokerCards.Add(_pokerCardDeck.GetSingleCard());
            }

            Assert.True(pokerCards.Distinct().Count().Equals(maxDeckCount));
        }
    }
}