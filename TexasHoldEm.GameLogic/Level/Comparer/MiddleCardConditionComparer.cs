using System.Linq;
using TexasHoldEm.GameLogic.Models;

namespace TexasHoldEm.GameLogic.Level.Comparer
{
    public class MiddleCardConditionComparer : IHandCardsComparer
    {
        public TexasGameResult GetCompareResult(
            TexasHoldEmPlayer blackPlayer,
            TexasHoldEmPlayer whitePlayer)
        {
            var texasGameResult = new TexasGameResult {WinLevel = new HighCardLevel().Name};
            
            const int middleValueIndex = 2;

            var blackPlayerMiddleCard = blackPlayer.HandCards.Cards.ElementAtOrDefault(middleValueIndex);
            var whitePlayerMiddleCard = whitePlayer.HandCards.Cards.ElementAtOrDefault(middleValueIndex);

            if (blackPlayerMiddleCard != null && whitePlayerMiddleCard != null)
            {
                var compareResult = blackPlayerMiddleCard.CompareTo(whitePlayerMiddleCard);
                if (compareResult > 0)
                {
                    texasGameResult.WinnerName = blackPlayer.Name;
                    texasGameResult.WinCard = blackPlayerMiddleCard.ToCardValueString();
                }
                else
                {
                    texasGameResult.WinnerName = whitePlayer.Name;
                    texasGameResult.WinCard = whitePlayerMiddleCard.ToCardValueString();
                }
            }

            return texasGameResult;
        }
    }
}