using TexasHoldEm.GameLogic.Level;
using Xunit;

namespace TexasHoldEm.GameLogic.Tests.Level
{
    public class FlushLevelTests : TexasLevelTestsBase
    {
        public FlushLevelTests() : base(new FlushLevel())
        {
        }

        #region IsThisLevel method tests

        [Fact]
        public void IsThisLevel_FlushLevelHandCards_ReturnsTrue()
        {
            // Arrange
            var handCards = CreateHandCardsByCardsString("2S 8S AS QS 3S");

            // Act
            var estimateResult = CurrentLevel.IsThisLevel(handCards);
            
            // Assert
            Assert.True(estimateResult);
        }

        [Theory]
        [InlineData("2S 3S 4S 5S 6S")]
        [InlineData("2S 3S 4S 5S 7H")]
        public void IsThisLevel_NotPureFlushLevelHandCards_ReturnFalse(string cardsString)
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
        public void GetSameLevelCompareResult_BlackPlayerHighCardLargerThanWhitePlayer_ReturnBlackWinResult()
        {
            // Arrange
            var blackPlayer = CreateBlackPlayer("2S 4S 5S 6S 8S");
            var whitePlayer = CreateWhitePlayer("2H 4H 5H 6H 7H");
            var expectedLevel = new HighCardLevel().Name;
            var expectedWinnerName = blackPlayer.Name;
            const string expectedWinCard = "8";
                        
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
            var blackPlayer = CreateBlackPlayer("2H 4H 5H 6H 7H");
            var whitePlayer = CreateWhitePlayer("2S 4S 5S 6S 8S");
            var expectedLevel = new HighCardLevel().Name;
            var expectedWinnerName = whitePlayer.Name;
            const string expectedWinCard = "8";
                        
            // Act
            var estimateResult = CurrentLevel.GetSameLevelCompareResult(blackPlayer, whitePlayer);
            
            // Assert
            Assert.Equal(expectedLevel, estimateResult.WinLevel);
            Assert.Equal(expectedWinnerName, estimateResult.WinnerName);
            Assert.Equal(expectedWinCard, estimateResult.WinCard);
        }

        [Fact]
        public void GetSameLevelCompareResult_BlackPlayerAndWhitePlayerHaveSameHighCard_ReturnTie()
        {
            // Arrange
            var blackPlayer = CreateBlackPlayer("2H 4H 5H 6H 7H");
            var whitePlayer = CreateWhitePlayer("2S 4S 5S 6S 7S");
            var expectedLevel = new HighCardLevel().Name;
            const string expectedWinnerName = null;
            const string expectedWinCard = null;
                        
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