using TexasHoldEm.GameLogic.Models;

namespace TexasHoldEm.GameLogic.Level.Comparer
{
    public interface IHandCardsComparer
    {
        TexasGameResult GetCompareResult(
            TexasHoldEmPlayer blackPlayer,
            TexasHoldEmPlayer whitePlayer);
    }
}