using Hurry.Helpers;
using Hurry.WpmTest;
using NUnit.Framework;

namespace Hurry.Tests;

[TestFixture]
public class ResultServiceTests
{
    #region GetErrors() Tests
    
    [Test]
    public void GetErrors_NoErrorsFound_NoErrorsReported()
    {
        // Arrange
        var test = new Test
        {
            UserInput = CreateCorrectInput(5),
            Prompt = CreateCorrectInput(5),
            SecondsElapsed = 5
        };
        
        // Act
        ResultHelper.GetErrors(test);

        // Assert
        Assert.AreEqual(0, test.Errors);
    }
    
    [Test]
    public void GetErrors_WithErrors_ErrorsReported()
    {
        // Arrange
        var test = new Test
        {
            UserInput = CreateCorrectInput(5),
            Prompt = CreateCorrectInput(4) + CreateWrongInput(1),
            SecondsElapsed = 5
        };
        
        // Act
        ResultHelper.GetErrors(test);

        // Assert
        Assert.AreEqual(1, test.Errors);
    }

    #endregion
    
    #region GetWordCount() Tests
    
    [Test]
    public void GetWordCount_HasWhitespace_ExpectedWordCount()
    {
        // Arrange
        var test = new Test
        {
            UserInput = CreateCorrectInput(5)
        };
        
        // Act
        var wordCount = ResultHelper.GetWordCount(test);

        // Assert
        Assert.AreEqual(5, wordCount);
    }
    
    [Test]
    public void GetWordCount_NoWhitespace_ExpectedWordCount()
    {
        // Arrange
        var test = new Test
        {
            UserInput = CreateCorrectInput(5, true)
        };
        
        // Act
        var wordCount = ResultHelper.GetWordCount(test);

        // Assert
        Assert.AreEqual(5, wordCount);
    }

    #endregion
    
    #region GetMinutes() Tests
    
    [Test]
    public void GetMinutes_LessThanOne_ExpectedMinuteCount()
    {
        // Arrange
        var test = new Test
        {
            SecondsElapsed = 30
        };
        
        // Act
        var minutes = ResultHelper.GetMinutes(test);
        
        // Assert
        Assert.AreEqual(.5, minutes);
    }
    
    [Test]
    public void GetMinutes_MoreThanOne_ExpectedMinuteCount()
    {
        // Arrange
        var test = new Test
        {
                SecondsElapsed = 90
        };
        
        // Act
        var minutes = ResultHelper.GetMinutes(test);
        
        // Assert
        Assert.AreEqual(1.5, minutes);
    }

    #endregion
    
    #region Helpers
    private static string CreateCorrectInput(int wordCount, bool hasWhitespace = false)
    {
        var result = "";
        if (hasWhitespace)
        {
            for (var i = 0; i < wordCount; i++) result += "word! ";

        }
        else
        {
            for (var i = 0; i < wordCount; i++) result += "word!";

        }

        return result;
    }

    private static string CreateWrongInput(int wordCount)
    {
        var result = "";

        for (var i = 0; i < wordCount; i++) result += "error! ";

        return result;
    }
    
    #endregion Helpers
}