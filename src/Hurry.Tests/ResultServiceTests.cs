using Hurry.Utilities.Models;
using Hurry.Utilities.Services;
using NUnit.Framework;

namespace Hurry.Tests;

[TestFixture]
public class ResultServiceTests
{
    [Test]
    public void LessThanOneMinuteAndNoErrors()
    {
        var test = new Test
        {
            UserInput = CreateCorrectInput(20),
            Prompt = CreateCorrectInput(20),
            Result =
            {
                SecondsElapsed = 20
            }
        };
        ResultService.GetWpm(test);

        Assert.AreEqual(60, test.Result!.Wpm);
    }
    
    [Test]
    public void LessThanOneMinuteAndHasErrors()
    {
        var test = new Test
        {
            UserInput = CreateCorrectInput(20),
            Prompt = CreateCorrectInput(19) + CreateWrongInput(1),
            Result =
            {
                SecondsElapsed = 20
            }
        };
        ResultService.GetWpm(test);

        Assert.AreEqual(57, test.Result!.Wpm);
    }
    
    [Test]
    public void MoreThanOneMinuteAndHasErrors()
    {
        var test = new Test
        {
            UserInput = CreateCorrectInput(80),
            Prompt = CreateCorrectInput(80),
            Result =
            {
                SecondsElapsed = 80
            }
        };
        ResultService.GetWpm(test);

        Assert.AreEqual(60, test.Result!.Wpm);
    }
    
    [Test]
    public void MoreThanOneMinuteAndNoErrors()
    {
        var test = new Test
        {
            UserInput = CreateCorrectInput(80),
            Prompt = CreateCorrectInput(70) + CreateWrongInput(10),
            Result =
            {
                SecondsElapsed = 80
            }
        };
        ResultService.GetWpm(test);

        Assert.AreEqual(52, test.Result!.Wpm);
    }
    
    #region Helpers

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
    
    #endregion
}