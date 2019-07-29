using System.Linq;
using TexasHoldEm.GameLogic.Models;

namespace TexasHoldEm.GameLogic.Level.Comparer
{
    public class HighCardConditionComparer : IHandCardsComparer
    {
        public TexasGameResult GetCompareResult(
            TexasHoldEmPlayer blackPlayer,
            TexasHoldEmPlayer whitePlayer)
        {
            var texasGameResult = new TexasGameResult {WinLevel = new HighCardLevel().Name};


            var blackPlayerHandCards = blackPlayer.HandCards.Cards;
            var whitePlayerHandCards = whitePlayer.HandCards.Cards;

            var compareResults = blackPlayerHandCards.Zip(whitePlayerHandCards, (black, white) =>
                black.CompareTo(white)).ToList();

            var blackLargeNumberIndex = compareResults.LastIndexOf(1);
            var whiteLargeNumberIndex = compareResults.LastIndexOf(-1);

            if (blackLargeNumberIndex > whiteLargeNumberIndex)
            {
                texasGameResult.WinnerName = blackPlayer.Name;
                texasGameResult.WinCard = blackPlayerHandCards.ElementAtOrDefault(blackLargeNumberIndex)?.ToCardValueString();
            }
            
            if (blackLargeNumberIndex < whiteLargeNumberIndex)
            {
                texasGameResult.WinnerName = whitePlayer.Name;
                texasGameResult.WinCard = whitePlayerHandCards.ElementAtOrDefault(whiteLargeNumberIndex)?.ToCardValueString();
            }
            
            return texasGameResult;
        }
    }
}