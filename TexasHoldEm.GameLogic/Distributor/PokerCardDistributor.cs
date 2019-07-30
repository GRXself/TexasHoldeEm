using System.Collections.Generic;
using TexasHoldEm.GameLogic.Models;

namespace TexasHoldEm.GameLogic.Distributor
{
    public class PokerCardDistributor
    {
        private readonly PokerCardDeck _pokerCardDeck;
        
        public PokerCardDistributor(PokerCardDeck pokerCardDeck)
        {
            _pokerCardDeck = pokerCardDeck;
        }

        public HandCards GetOneSetHandCards()
        {
            return new HandCards(_pokerCardDeck.GetCards(5));
        }
    }
}