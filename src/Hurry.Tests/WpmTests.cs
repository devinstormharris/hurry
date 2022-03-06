using Hurry.Utilities.Models;
using Hurry.Utilities.Services;
using NUnit.Framework;

namespace Hurry.Tests;

/// <summary>
/// Tests the results of the typing test
/// </summary>
public class WpmTests
{
    private ResultsService _resultsService;
    private Test _test;
    
    /// <summary>
    /// Initializes ResultsService
    /// </summary>
    [SetUp]
    public void Setup()
    {
        // We are creating new test results.
        _resultsService = new ResultsService();
        _test = new Test();
    }
    
    /// <summary>
    /// Assert that we get expected WPM from ResultsService when time elapsed is less than 1 minute.
    /// </summary>
    [Test]
    public void TimeElapsedLessThan60()
    {
        _test.UserInput = CreateInput(20);
        _test.SecondsElapsed = 20;
        
        var wpm = _resultsService.CalculateWpm(_test);
        Assert.AreEqual(60, wpm);
    }
    
    /// <summary>
    /// Assert that we get expected WPM from ResultsService when time elapsed is more than 1 minute.
    /// </summary>
    [Test]
    public void TimeElapsedMoreThan60()
    {
        _test.UserInput = CreateInput(80);
        _test.SecondsElapsed = 80;
        
        var wpm = _resultsService.CalculateWpm(_test);
        Assert.AreEqual(60, wpm);
    }

    /// <summary>
    /// Returns an array of chars that is equal to the word count that is indicated by param.
    /// </summary>
    /// <param name="wordCount">Amount of words desired.</param>
    /// <returns>Array of chars indicating word count.</returns>
    private static char[] CreateInput(int wordCount)
    {
        var input = "";

        for (var i = 0; i < wordCount; i++)
        {
            input += "word!";
        }

        return input.ToCharArray();
    }
}