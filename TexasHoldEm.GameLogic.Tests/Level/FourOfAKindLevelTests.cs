using TexasHoldEm.GameLogic.Level;
using Xunit;

namespace TexasHoldEm.GameLogic.Tests.Level
{
    public class FourOfAKindLevelTests : TexasLevelTestsBase
    {
        public FourOfAKindLevelTests() : base(new FourOfAKindLevel())
        {
        }

        #region IsThisLevel method tests

        [Fact]
        public void IsThisLevel_FourOfAKindLevelHandCards_ReturnTrue()
        {
            // Arrange
            var handCards = CreateHandCardsByCardsString("2D 2S 2H 2C 3D");
            
            // Act
            var estimateResult = CurrentLevel.IsThisLevel(handCards);
            
            // Assert
            Assert.True(estimateResult);
        }

        [Theory]
        [InlineData("2D 2S 2H 3C 3D")]
        [InlineData("2D 2S 3H 3C 4D")]
        public void IsThisLevel_NotFourOfAKindHandCards_ReturnFalse(string cardsString)
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
        public void GetSameLevelCompareResult_BlackPlayerFourOfAKindCardLargerThanWhitePlayer_ReturnBlackWinResult()
        {
            // Arrange
            var blackPlayer = CreateBlackPlayer("2S 4D 4S 4H 4C");
            var whitePlayer = CreateWhitePlayer("2H 3D 3S 3H 3C");
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
        public void GetSameLevelCompareResult_WhitePlayerFourOfAKindCardLargerThanBlackPlayer_ReturnWhiteWinResult()
        {
            // Arrange
            var blackPlayer = CreateBlackPlayer("2H 3D 3S 3H 3C");
            var whitePlayer = CreateWhitePlayer("2S 4D 4S 4H 4C");
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