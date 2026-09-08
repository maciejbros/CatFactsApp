using CatFactsApp.Services;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

services.AddHttpClient<ICatFactService, CatFactService>();
services.AddSingleton<IFileService, FileService>();

var serviceProvider = services.BuildServiceProvider();

var catFactService = serviceProvider.GetRequiredService<ICatFactService>();
var fileService = serviceProvider.GetRequiredService<IFileService>();

while (true)
{
    Console.Clear();

    Console.WriteLine("      CAT FACTS");
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine("[ENTER] Get new cat fact");
    Console.WriteLine("[H]     Show history");
    Console.WriteLine("[S]     Show statistics");
    Console.WriteLine("[C]     Clear history");
    Console.WriteLine("[ESC]   Exit");
    Console.WriteLine();

    var key = Console.ReadKey(true);

    if (key.Key == ConsoleKey.Escape)
    {
        break;
    }

    if (key.Key == ConsoleKey.Enter)
    {
        await GetNewFactAsync();
    }
    else if (key.Key == ConsoleKey.H)
    {
        await ShowHistoryAsync();
    }
    else if (key.Key == ConsoleKey.S)
    {
        await ShowStatisticsAsync();
    }
    else if (key.Key == ConsoleKey.C)
    {
        await ClearHistoryAsync();
    }
}

async Task GetNewFactAsync()
{
    Console.Clear();

    Console.WriteLine("      CAT FACTS");
    Console.WriteLine();
    Console.WriteLine();

    try
    {
        var catFact = await catFactService.GetCatFactAsync();

        Console.WriteLine($"Fact: {catFact.Fact}");
        Console.WriteLine();
        Console.WriteLine($"Length: {catFact.Length}");

        await fileService.AppendFactAsync(
            catFact.Fact,
            catFact.Length);

        Console.WriteLine();
        Console.WriteLine("Fact saved successfully.");
    }
    catch (Exception ex)
    {
        Console.WriteLine();
        Console.WriteLine($"An error occurred: {ex.Message}");
    }

    Console.WriteLine();
    Console.WriteLine("Press any key to return to the menu...");
    Console.ReadKey(true);
}

async Task ShowHistoryAsync()
{
    Console.Clear();

    Console.WriteLine("       HISTORY");
    Console.WriteLine();
    Console.WriteLine();

    var history = await fileService.GetHistoryAsync();

    if (history.Count == 0)
    {
        Console.WriteLine("No facts found.");
    }
    else
    {
        for (int i = 0; i < history.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {history[i]}");
            Console.WriteLine();
        }

        Console.WriteLine($"Total facts: {history.Count}");
    }

    Console.WriteLine();
    Console.WriteLine("Press any key to return to the menu...");
    Console.ReadKey(true);
}

async Task ShowStatisticsAsync()
{
    Console.Clear();

    Console.WriteLine("      STATISTICS");
    Console.WriteLine();
    Console.WriteLine();

    var history = await fileService.GetHistoryAsync();

    if (history.Count == 0)
    {
        Console.WriteLine("No facts available for statistics.");
    }
    else
    {
        var lengths = history
            .Select(line =>
            {
                var parts = line.Split('|');
                return int.Parse(parts[^1].Trim());
            })
            .ToList();

        var totalFacts = history.Count;
        var averageLength = lengths.Average();
        var shortestLength = lengths.Min();
        var longestLength = lengths.Max();

        Console.WriteLine($"Total facts:       {totalFacts}");
        Console.WriteLine($"Average length:    {averageLength:F2}");
        Console.WriteLine($"Shortest fact:     {shortestLength}");
        Console.WriteLine($"Longest fact:      {longestLength}");
    }

    Console.WriteLine();
    Console.WriteLine("Press any key to return to the menu...");
    Console.ReadKey(true);
}

async Task ClearHistoryAsync()
{
    Console.Clear();


    Console.WriteLine("     CLEAR HISTORY");
    Console.WriteLine();
    Console.WriteLine();

    var history = await fileService.GetHistoryAsync();

    if (history.Count == 0)
    {
        Console.WriteLine("History is already empty.");
    }
    else
    {
        Console.WriteLine(
            $"Are you sure you want to delete {history.Count} facts?");

        Console.WriteLine();
        Console.WriteLine("[Y] Yes");
        Console.WriteLine("[N] No");

        var key = Console.ReadKey(true);

        if (key.Key == ConsoleKey.Y)
        {
            await fileService.ClearHistoryAsync();

            Console.WriteLine();
            Console.WriteLine("History cleared successfully.");
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("Operation cancelled.");
        }
    }

    Console.WriteLine();
    Console.WriteLine("Press any key to return to the menu...");
    Console.ReadKey(true);
}