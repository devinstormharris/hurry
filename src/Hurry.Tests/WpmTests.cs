using Hurry.Utilities.Services;
using NUnit.Framework;

namespace Hurry.Tests;

/// <summary>
///     Tests the results of the typing test
/// </summary>
public class WpmTests
{
    private TestService _testService = null!;

    /// <summary>
    ///     Initializes ResultsService
    /// </summary>
    [SetUp]
    public void Setup()
    {
        // We are creating new test results.
        _testService = new TestService();
    }

    /// <summary>
    ///     Assert that we get expected WPM from ResultsService when time elapsed is less than 1 minute.
    /// </summary>
    [Test]
    public void TimeElapsedLessThan60()
    {
        var input = CreateInput(20);

        _testService.Test.SecondsElapsed = 20;
        _testService.CalculateWpm(input);

        Assert.AreEqual(60, _testService.Test.Result!.Wpm);
    }

    /// <summary>
    ///     Assert that we get expected WPM from ResultsService when time elapsed is more than 1 minute.
    /// </summary>
    [Test]
    public void TimeElapsedMoreThan60()
    {
        var input = CreateInput(80);

        _testService.Test.SecondsElapsed = 80;
        _testService.CalculateWpm(input);

        Assert.AreEqual(60, _testService.Test.Result!.Wpm);
    }

    /// <summary>
    ///     Returns an array of chars that is equal to the word count that is indicated by param.
    /// </summary>
    /// <param name="wordCount">Amount of words desired.</param>
    /// <returns>Array of chars indicating word count.</returns>
    private static string CreateInput(int wordCount)
    {
        var result = "";

        for (var i = 0; i < wordCount; i++) result += "word!";

        return result;
    }
}