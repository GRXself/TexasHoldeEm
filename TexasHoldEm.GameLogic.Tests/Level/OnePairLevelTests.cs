using TexasHoldEm.GameLogic.Level;
using Xunit;

namespace TexasHoldEm.GameLogic.Tests.Level
{
    public class OnePairLevelTests : TexasLevelTestsBase
    {
        public OnePairLevelTests() : base(new OnePairLevel())
        {
        }
        
        #region IsThisLevel method tests

        [Fact]
        public void IsThisLevel_OnePairLevelHandCards_ReturnsTrue()
        {
            // Arrange
            var handCards = CreateHandCardsByCardsString("2S 2D 3D 4H 5C");

            // Act
            var estimateResult = CurrentLevel.IsThisLevel(handCards);
            
            // Assert
            Assert.True(estimateResult);
        }

        [Theory]
        [InlineData("2D 2H 2S 3D 3H")]
        [InlineData("2D 2H 3D 3H 4D")]
        public void IsThisLevel_NotPureOnePairLevelHandCards_ReturnFalse(string cardsString)
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
            var blackPlayer = CreateBlackPlayer("2D 2H 3D 4D 6D");
            var whitePlayer = CreateWhitePlayer("2S 2C 3H 4H 5H");
            var expectedLevel = new HighCardLevel().Name;
            var expectedWinnerName = blackPlayer.Name;
            const string expectedWinCard = "6";
                        
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
            var blackPlayer = CreateBlackPlayer("2S 2C 3H 4H 5H");
            var whitePlayer = CreateWhitePlayer("2D 2H 3D 4D 6D");
            var expectedLevel = new HighCardLevel().Name;
            var expectedWinnerName = whitePlayer.Name;
            const string expectedWinCard = "6";
                        
            // Act
            var estimateResult = CurrentLevel.GetSameLevelCompareResult(blackPlayer, whitePlayer);
            
            // Assert
            Assert.Equal(expectedLevel, estimateResult.WinLevel);
            Assert.Equal(expectedWinnerName, estimateResult.WinnerName);
            Assert.Equal(expectedWinCard, estimateResult.WinCard);
        }
        
        [Fact]
        public void GetSameLevelCompareResult_BlackPlayerPairCardLargerThanWhitePlayer_ReturnBlackWinResult()
        {
            // Arrange
            var blackPlayer = CreateBlackPlayer("2D 3D 4D 5D 5H");
            var whitePlayer = CreateWhitePlayer("2S 3S 4S 4H 5S");
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
        public void GetSameLevelCompareResult_WhitePlayerPairCardLargerThanBlackPlayer_ReturnWhiteWinResult()
        {
            // Arrange
            var blackPlayer = CreateBlackPlayer("2S 3S 4S 4H 5S");
            var whitePlayer = CreateWhitePlayer("2D 3D 4D 5D 5H");
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

        [Fact]
        public void GetSameLevelCompareResult_BlackPlayerAndWhitePlayerHaveSameHighCard_ReturnTie()
        {
            // Arrange
            var blackPlayer = CreateBlackPlayer("2D 2H 3D 4D 5D");
            var whitePlayer = CreateWhitePlayer("2S 2C 3H 4H 5H");
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
