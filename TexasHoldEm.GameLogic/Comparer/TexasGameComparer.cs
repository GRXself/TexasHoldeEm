using TexasHoldEm.GameLogic.Models;

namespace TexasHoldEm.GameLogic.Comparer
{
    public static class TexasGameComparer
    {
        public static TexasGameResult CompareHandCards(TexasHoldEmPlayer blackPlayer, TexasHoldEmPlayer whitePlayer)
        {
            var texasGameResult = new TexasGameResult();

            var blackPlayerHandCardLevel = blackPlayer.HandCards.GetHandCardsLevel();
            var whitePlayerHandCardLevel = whitePlayer.HandCards.GetHandCardsLevel();

            var compareResult = blackPlayerHandCardLevel.CompareTo(whitePlayerHandCardLevel);
            if (compareResult > 0)
            {
                texasGameResult.WinnerName = blackPlayer.Name;
                texasGameResult.WinLevel = blackPlayerHandCardLevel.Name;
            }
            else if (compareResult < 0)
            {
                texasGameResult.WinnerName = whitePlayer.Name;
                texasGameResult.WinLevel = whitePlayerHandCardLevel.Name;
            }
            else
            {
                texasGameResult = blackPlayerHandCardLevel.GetSameLevelCompareResult(blackPlayer, whitePlayer);
            }

            return texasGameResult;
        }
    }
}