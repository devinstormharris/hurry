using Hurry.Utilities.Models;

namespace Hurry.Utilities.Services.Interfaces;

public interface IResultsService
{
    Test CalculateWpm(Test test, string input);
}