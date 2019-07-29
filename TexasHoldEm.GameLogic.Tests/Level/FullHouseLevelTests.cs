using TexasHoldEm.GameLogic.Level;
using Xunit;

namespace TexasHoldEm.GameLogic.Tests.Level
{
    public class FullHouseLevelTests : TexasLevelTestsBase
    {
        public FullHouseLevelTests() : base(new FullHouseLevel())
        {
        }

        #region IsThisLevel method tests

        [Fact]
        public void IsThisLevel_FullHouseLevelHandCards_ReturnsTrue()
        {
            // Arrange
            var handCards = CreateHandCardsByCardsString("2S 2H 3S 3H 3D");

            // Act
            var estimateResult = CurrentLevel.IsThisLevel(handCards);
            
            // Assert
            Assert.True(estimateResult);
        }

        [Theory]
        [InlineData("2S 2H 3S 3H 4D")]
        [InlineData("2S 2H 2D 3S 4D")]
        public void IsThisLevel_NotFullHouseLevelHandCards_ReturnFalse(string cardsString)
        {
            // Arrange
            var handCards = CreateHandCardsByCardsString(cardsString);
            
            // Act
            var estimateResult = CurrentLevel.IsThisLevel(handCards);
            
            // Assert
            Assert.False(estimateResult);
        }

        #endregion

        #region GetSameLevelCompareResult method tests

        [Fact]
        public void GetSameLevelCompareResult_BlackPlayerThreeOfAKindCardLargerThanWhitePlayer_ReturnBlackWinResult()
        {
            // Arrange
            var blackPlayer = CreateBlackPlayer("2D 2C 4D 4H 4S");
            var whitePlayer = CreateWhitePlayer("2S 2H 3S 3H 3D");
            var expectedLevel = new HighCardLevel().Name;
            var expectedWinnerName = blackPlayer.Name;
            const string expectedWinCard = "4";
                        
            // Act
            var estimateResult = CurrentLevel.GetSameLevelCompareResult(blackPlayer, whitePlayer);
            
            // Assert
            Assert.Equal(expectedLevel, estimateResult.WinLevel);
            Assert.Equal(expectedWinnerName, estimateResult.WinnerName);
            Assert.Equal(expectedWinCard, estimateResult.WinCard);
        }

        [Fact]
        public void GetSameLevelCompareResult_WhitePlayerHighCardLargerThanBlackPlayer_ReturnWhiteWinResult()
        {
            // Arrange
            var blackPlayer = CreateBlackPlayer("2S 2H 3S 3H 3D");
            var whitePlayer = CreateWhitePlayer("2D 2C 4D 4H 4S");
            var expectedLevel = new HighCardLevel().Name;
            var expectedWinnerName = whitePlayer.Name;
            const string expectedWinCard = "4";
                        
            // Act
            var estimateResult = CurrentLevel.GetSameLevelCompareResult(blackPlayer, whitePlayer);
            
            // Assert
            Assert.Equal(expectedLevel, estimateResult.WinLevel);
            Assert.Equal(expectedWinnerName, estimateResult.WinnerName);
            Assert.Equal(expectedWinCard, estimateResult.WinCard);
        }

        #endregion
    }
}