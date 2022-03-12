﻿using Hurry.Console.Helpers;
using Hurry.Utilities.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Hurry.Console;

public static class Program
{
    private static TestService _testService = null!;

    private static async Task Main()
    {
        var services = new ServiceCollection()
            .AddSingleton(TestService.GetInstance());

        await using var serviceProvider = services.BuildServiceProvider();
        _testService = serviceProvider.GetService<TestService>()!;

        await _testService.Start();
    }
}