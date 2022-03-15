using Hurry.Utilities.Models;

namespace Hurry.Utilities.Services;

public class AccuracyService
{
    public Test CalculateAccuracy(Test test)
    {
        var accuracy = 1.0;
        var errors = 0.0;

        var prompt = test.Prompt.Split();
        var userInput = test.UserInput.Split();

        for (int i = 0; i < userInput.Length; i++)
        {
            if (prompt[i] != userInput[i])
            {
                errors++;
            }
        }

        if (errors > 0)
        {
            accuracy = 1 - Math.Round(errors / userInput.Length, 1);
        }

        test.Result.Accuracy = accuracy;
        
        return test;
    }
}