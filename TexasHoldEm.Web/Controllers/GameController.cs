using Microsoft.AspNetCore.Mvc;
using TexasHoldEm.GameLogic.Comparer;
using TexasHoldEm.GameLogic.Distributor;
using TexasHoldEm.GameLogic.Models;
using TexasHoldEm.Web.Models;

namespace TexasHoldEm.Web.Controllers
{
    public class GameController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult<TexasGameResult> GetGameResult(GameDataModel gameData)
        {
            var player1 = new TexasHoldEmPlayer(gameData.PlayerOneName);
            var player2 = new TexasHoldEmPlayer(gameData.PlayerTwoName);
            
            player1.HandCards = new HandCards(gameData.PlayerOneCards);
            player2.HandCards = new HandCards(gameData.PlayerTwoCards);
            
            return TexasGameComparer.CompareHandCards(player1, player2);
        }

        public ActionResult<string> GetRandomTexasHandCards()
        {
            return new PokerCardDistributor(PokerCardDeck.GetInstance()).GetOneSetHandCards().ToString();
        }

        public ActionResult<string> RefreshPokerCardDeck()
        {
            PokerCardDeck.RefreshInstance();
            return "Deck changed";
        }
    }
}