using Hurry.Utilities.Models;
using Hurry.Utilities.Services;
using NUnit.Framework;

namespace Hurry.Tests;

[TestFixture]
public class ResultServiceTests
{
    [Test]
    public void GetErrors_NoErrorsFound_NoErrorsReported()
    {
        // Arrange
        var test = new Test
        {
            UserInput = CreateCorrectInput(5),
            Prompt = CreateCorrectInput(5),
            Result =
            {
                SecondsElapsed = 5
            }
        };
        
        // Act
        ResultService.GetErrors(test);

        // Assert
        Assert.AreEqual(0, test.Result!.Errors);
    }
    
    [Test]
    public void GetErrors_WithErrors_ErrorsReported()
    {
        // Arrange
        var test = new Test
        {
            UserInput = CreateCorrectInput(5),
            Prompt = CreateCorrectInput(4) + CreateWrongInput(1),
            Result =
            {
                SecondsElapsed = 5
            }
        };
        
        // Act
        ResultService.GetErrors(test);

        // Assert
        Assert.AreEqual(1, test.Result!.Errors);
    }

    [Test]
    public void GetWordCount_HasWhitespace_ExpectedWordCount()
    {
        // Arrange
        var test = new Test
        {
            UserInput = CreateCorrectInput(5)
        };
        
        // Act
        var wordCount = ResultService.GetWordCount(test);

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
        var wordCount = ResultService.GetWordCount(test);

        // Assert
        Assert.AreEqual(5, wordCount);
    }

    [Test]
    public void GetMinutes_LessThanOne_ExpectedMinuteCount()
    {
        // Arrange
        var test = new Test
        {
            Result =
            {
                SecondsElapsed = 30
            }
        };
        
        // Act
        var minutes = ResultService.GetMinutes(test);
        
        // Assert
        Assert.AreEqual(.5, minutes);
    }
    
    [Test]
    public void GetMinutes_MoreThanOne_ExpectedMinuteCount()
    {
        // Arrange
        var test = new Test
        {
            Result =
            {
                SecondsElapsed = 90
            }
        };
        
        // Act
        var minutes = ResultService.GetMinutes(test);
        
        // Assert
        Assert.AreEqual(1.5, minutes);
    }

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
}