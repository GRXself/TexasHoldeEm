using TexasHoldEm.GameLogic.Level;
using Xunit;

namespace TexasHoldEm.GameLogic.Tests.Level
{
    public class ThreeOfAKindLevelTests : TexasLevelTestsBase
    {
        public ThreeOfAKindLevelTests() : base(new ThreeOfAKindLevel())
        {
        }
        
        #region IsThisLevel method tests

        [Fact]
        public void GivenThreeOfAKindLevelHandCards_ReturnsTrue()
        {
            // Arrange
            var handCards = CreateHandCardsByCardsString("2S 3S 4D 4H 4C");

            // Act
            var estimateResult = CurrentLevel.IsThisLevel(handCards);
            
            // Assert
            Assert.True(estimateResult);
        }

        [Theory]
        [InlineData("2S 2D 4D 4H 4C")]
        [InlineData("2S 2D 2H 2C 5C")]
        [InlineData("2S 2D 3D 4H 5C")]
        [InlineData("2S 2D 3D 3H 4C")]
        public void GivenNotPureThreeOfAKindLevelHandCards_ReturnFalse(string cardsString)
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
        public void GivenBlackPlayerThreeOfAKindCardLargerThanWhitePlayer_ReturnBlackWinResult()
        {
            // Arrange
            var blackPlayer = CreateBlackPlayer("2S 3S 5S 5H 5C");
            var whitePlayer = CreateWhitePlayer("2H 3D 4S 4H 4C");
            var expectedLevel = new HighCardLevel().Name;
            var expectedWinnerName = blackPlayer.Name;
            const string expectedWinCard = "5";
                        
            // Act
            var estimateResult = CurrentLevel.GetSameLevelCompareResult(blackPlayer, whitePlayer);
            
            // Assert
            Assert.Equal(expectedLevel, estimateResult.WinLevel);
            Assert.Equal(expectedWinnerName, estimateResult.WinnerName);
            Assert.Equal(expectedWinCard, estimateResult.WinCard);
        }

        [Fact]
        public void GivenWhitePlayerThreeOfAKindCardLargerThanBlackPlayer_ReturnWhiteWinResult()
        {
            // Arrange
            var blackPlayer = CreateBlackPlayer("2H 3D 4S 4H 4C");
            var whitePlayer = CreateWhitePlayer("2S 3S 5S 5H 5C");
            var expectedLevel = new HighCardLevel().Name;
            var expectedWinnerName = whitePlayer.Name;
            const string expectedWinCard = "5";
                        
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