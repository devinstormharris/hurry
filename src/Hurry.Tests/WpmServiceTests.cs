using Hurry.Utilities.Services;
using NUnit.Framework;

namespace Hurry.Tests;

public class WpmServiceTests
{
    #region Helpers
    
    private static string CreateInput(int wordCount)
    {
        var result = "";

        for (var i = 0; i < wordCount; i++) result += "word!";

        return result;
    }

    #endregion

    #region Setup

    private TestService _testService = null!;
    
    [SetUp]
    public void Setup()
    {
        _testService = new TestService();
    }

    #endregion

    #region Tests

    [Test]
    public void WpmServiceTests_TimeElapsedLessThan60()
    {
        var input = CreateInput(20);

        _testService.Test.Response.SecondsElapsed = 20;
        _testService.CalculateWpm(input);

        Assert.AreEqual(60, _testService.Test.Result!.Wpm);
    }
    
    [Test]
    public void WpmServiceTests_TimeElapsedMoreThan60()
    {
        var input = CreateInput(80);

        _testService.Test.Response.SecondsElapsed = 80;
        _testService.CalculateWpm(input);

        Assert.AreEqual(60, _testService.Test.Result!.Wpm);
    }

    #endregion
}