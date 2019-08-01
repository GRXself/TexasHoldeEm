using System;
using System.Collections.Generic;
using System.Linq;
using TexasHoldEm.GameLogic.Core;

namespace TexasHoldEm.GameLogic.Models
{
    public class PokerCardDeck
    {
        private static PokerCardDeck _instance = new PokerCardDeck();
        
        public int CurrentCardsCount { get; set; }

        public List<PokerCard> PokerCards { get; }

        private PokerCardDeck()
        {
            CurrentCardsCount = 52;
            PokerCards = GetInitialDeck();
        }

        public static PokerCardDeck GetInstance()
        {
            return _instance;
        }

        public static void RefreshInstance()
        {
            _instance = new PokerCardDeck();
        }

        public PokerCard GetSingleCard()
        {
            var randomIndex = GetRandomIndex();
            if (randomIndex < 0)
            {
                return null;
            }

            var pokerCard = PokerCards.ElementAt(randomIndex);
                
            PokerCards.RemoveAt(randomIndex);
            CurrentCardsCount--;

            return pokerCard;
        }

        public List<PokerCard> GetCards(int cardCount)
        {
            var pokerCards = new List<PokerCard>();
            
            for (var i = 0; i < cardCount; i++)
            {
                pokerCards.Add(GetSingleCard());
            }

            return pokerCards;
        }

        public bool HasNextCard()
        {
            return CurrentCardsCount > 0;
        }

        private int GetRandomIndex()
        {
            var randomIndexGenerator = new Random();
            if (!HasNextCard())
            {
                return -1;
            }

            return randomIndexGenerator.Next(0, CurrentCardsCount);
        }

        private static List<PokerCard> GetInitialDeck()
        {
            var pokerCards = new List<PokerCard>();
            
            const string cardValue = "2 3 4 5 6 7 8 9 T J Q K A";
            var noColorCard = cardValue.Split(" ").ToList();

            var colors = Enum.GetValues(typeof(PokerCardColor));

            foreach (var color in colors)
            {
                noColorCard.ForEach(card => pokerCards.Add(new PokerCard(card + color)));
            }

            return pokerCards;
        }
    }
}