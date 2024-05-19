using System.Net.NetworkInformation;
using System.Text;

namespace TenPinBowling.Unit.Tests;

public class TenPinBowlingGameTests
{
    public static IEnumerable<object[]> SingleFrameTestDataOpen => GetTestDataSingleFrameOpenSets();
    public static IEnumerable<object[]> TenFramesTestDataOpen => GetTestDataTenFramesAllOpenSets();

    [Theory]
    [MemberData(nameof(SingleFrameTestDataOpen))]
    public void MethodScore_SingleFrame_KnockedOverLessThanTenPins_ExpectedScore(string playerScoresPerFrame, int expectedScore)
    {
        // Arrange
        // Act
        int actual = TenPinBowlingGame.Score(playerScoresPerFrame);
        

        // Assert
        Assert.Equal(expectedScore, actual);
    }

    [Theory]
    [MemberData(nameof(TenFramesTestDataOpen))]
    public void MethodScore_TenFrames_AllOpenSets_ExpectedScore(string playerScoresPerFrame, int expectedScore)
    {
        // Arrange
        // Act
        int actual = TenPinBowlingGame.Score(playerScoresPerFrame);

        // Assert
        Assert.Equal(expectedScore, actual);
    }

    // [Fact]
    // public void ScoreMethod_WithSingleFrameIsASpare_ResultTen()
    // {
    //     // Arrange
    //     string playerScoresPerFrame = "5/";
    //     int expected = 10;

    //     // Act
    //     int actual = TenPinBowlingGame.Score(playerScoresPerFrame);

    //     // Assert
    //     Assert.Equal(expected, actual);
    // }

    private static IEnumerable<object[]> GetTestDataTenFramesAllOpenSets()
    {
        StringBuilder sb = new StringBuilder();
        int expectedResult = 0;

        for (int frame = 1; frame <= 10; frame++)
        {
            Random random = new Random();
            int firstRoll = random.Next(1, 9); // Creates a random number from 1 to 8
            // Creates a random number based on firstRoll + secondRoll < 10
            int secondRoll = random.Next(1, 9 - firstRoll);

            if (frame == 10)
            {
                sb.Append($"{firstRoll} {secondRoll}");
            }
            else
            {
                sb.Append($"{firstRoll} {secondRoll} ");
            }

            expectedResult += firstRoll + secondRoll;
        }

        yield return new object[] { sb.ToString(), expectedResult };
    }

    /// <summary>
    /// Creates combinations of two rolls that are less than 10.
    /// </summary>
    /// <returns>
    /// object[] { "1 1", 2 }
    /// </returns>
    private static IEnumerable<object[]> GetTestDataSingleFrameOpenSets()
    {
        for (int firstRoll = 1; firstRoll <= 9; firstRoll++)
        {
            for (int secondRoll = 1; secondRoll <= 9; secondRoll++)
            {
                if (firstRoll + secondRoll < 10)
                {
                    yield return new object[] { $"{firstRoll} {secondRoll}", firstRoll + secondRoll };
                }
            }
        }
    }

}