using System.Collections.Generic;
using System.Linq;
using TexasHoldEm.GameLogic.Models;

namespace TexasHoldEm.GameLogic.Level.Comparer
{
    public class PairConditionComparer : IHandCardsComparer
    {
        public TexasGameResult GetCompareResult(
            TexasHoldEmPlayer blackPlayer,
            TexasHoldEmPlayer whitePlayer)
        {
            var texasGameResult = new TexasGameResult {WinLevel = new HighCardLevel().Name};
            
            var blackPlayerHandCards = blackPlayer.HandCards.Cards;
            var whitePlayerHandCards = whitePlayer.HandCards.Cards;

            var blackPlayerPairCards = GetPairCards(blackPlayerHandCards);
            var whitePlayerPairCards = GetPairCards(whitePlayerHandCards);

            var compareResults = blackPlayerPairCards.Zip(whitePlayerPairCards, (black, white) =>
                black.CompareTo(white)).ToList();
            
            var blackLargeNumberIndex = compareResults.LastIndexOf(1);
            var whiteLargeNumberIndex = compareResults.LastIndexOf(-1);
            
            if (blackLargeNumberIndex > whiteLargeNumberIndex)
            {
                texasGameResult.WinnerName = blackPlayer.Name;
                texasGameResult.WinCard = blackPlayerPairCards.ElementAtOrDefault(blackLargeNumberIndex)?.ToCardValueString();
            }
            
            if (blackLargeNumberIndex < whiteLargeNumberIndex)
            {
                texasGameResult.WinnerName = whitePlayer.Name;
                texasGameResult.WinCard = whitePlayerPairCards.ElementAtOrDefault(whiteLargeNumberIndex)?.ToCardValueString();
            }

            if (string.IsNullOrEmpty(texasGameResult.WinnerName))
            {
                texasGameResult = new HighCardConditionComparer().GetCompareResult(
                    blackPlayer, whitePlayer);
            }

            return texasGameResult;
        }

        private static List<PokerCard> GetPairCards(List<PokerCard> cards)
        {
            return cards.FindAll(c1 => cards.Count(c2 => c1.CompareTo(c2).Equals(0)).Equals(2))
                .Distinct()
                .ToList();
        }
    }
}