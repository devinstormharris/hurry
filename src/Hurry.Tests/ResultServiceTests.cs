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

    private static string CreateCorrectInput(int wordCount)
    {
        var result = "";

        for (var i = 0; i < wordCount; i++) result += "word! ";

        return result;
    }

    private static string CreateWrongInput(int wordCount)
    {
        var result = "";

        for (var i = 0; i < wordCount; i++) result += "error! ";

        return result;
    }
}