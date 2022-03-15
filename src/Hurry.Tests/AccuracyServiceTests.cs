using Hurry.Utilities.Services;
using NUnit.Framework;

namespace Hurry.Tests;

public class AccuracyServiceTests
{
    #region Helpers

    private static string CreateInput(int wordCount)
    {
        var result = "";

        for (var i = 0; i < wordCount; i++) result += "word! ";

        return result;
    }

    #endregion

    #region Setup

    private TestService _testService = null!;

    [SetUp]
    public void Setup()
    {
        _testService = TestService.GetInstance();
    }

    #endregion

    #region Tests

    [Test]
    public void AccuracyService_NoErrors()
    {
        _testService.Test.UserInput = CreateInput(20);
        _testService.Test.Prompt = CreateInput(20);
        _testService.CalculateAccuracy();

        Assert.AreEqual(1, _testService.Test.Result!.Accuracy);
    }

    [Test]
    public void AccuracyService_Errors()
    {
        _testService.Test.UserInput = CreateInput(5);
        _testService.Test.Prompt = CreateInput(4) + "word. ";
        _testService.CalculateAccuracy();

        Assert.AreEqual(0.8, _testService.Test.Result!.Accuracy);
    }
    #endregion
}