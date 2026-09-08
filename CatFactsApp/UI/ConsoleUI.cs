using CatFactsApp.Services.Interfaces;

namespace CatFactsApp.UI;

public class ConsoleUI
{
    private readonly ICatFactService _catFactService;
    private readonly IFileService _fileService;

    public ConsoleUI(
        ICatFactService catFactService,
        IFileService fileService)
    {
        _catFactService = catFactService;
        _fileService = fileService;
    }

    public async Task RunAsync()
    {
        while (true)
        {
            ShowMenu();

            var key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.Escape)
            {
                break;
            }

            switch (key.Key)
            {
                case ConsoleKey.Enter:
                    await GetNewFactAsync();
                    break;

                case ConsoleKey.H:
                    await ShowHistoryAsync();
                    break;

                case ConsoleKey.S:
                    await ShowStatisticsAsync();
                    break;

                case ConsoleKey.C:
                    await ClearHistoryAsync();
                    break;
            }
        }
    }

    private void ShowMenu()
    {
        Console.Clear();

        Console.WriteLine(ConsoleConstants.AppTitle);
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine(ConsoleConstants.GetNewFactOption);
        Console.WriteLine(ConsoleConstants.HistoryOption);
        Console.WriteLine(ConsoleConstants.StatisticsOption);
        Console.WriteLine(ConsoleConstants.ClearHistoryOption);
        Console.WriteLine(ConsoleConstants.ExitOption);
        Console.WriteLine();
    }

    private async Task GetNewFactAsync()
    {
        Console.Clear();

        Console.WriteLine(ConsoleConstants.AppTitle);
        Console.WriteLine();
        Console.WriteLine();

        try
        {
            var catFact = await _catFactService.GetCatFactAsync();

            Console.WriteLine($"{ConsoleConstants.FactLabel} {catFact.Fact}"); 
            Console.WriteLine();
            Console.WriteLine($"{ConsoleConstants.LengthLabel} {catFact.Length}");

            await _fileService.AppendFactAsync(
                catFact.Fact,
                catFact.Length);

            Console.WriteLine();
            Console.WriteLine(ConsoleConstants.FactSaved);
        }
        catch (Exception ex)
        {
            Console.WriteLine();
            Console.WriteLine(string.Format(ConsoleConstants.ErrorMessage, ex.Message));
        }

        WaitForKey();
    }

    private async Task ShowHistoryAsync()
    {
        Console.Clear();

        Console.WriteLine(ConsoleConstants.HistoryTitle);
        Console.WriteLine();
        Console.WriteLine();

        var history = await _fileService.GetHistoryAsync();

        if (history.Count == 0)
        {
            Console.WriteLine(ConsoleConstants.NoFactsFound);
        }
        else
        {
            for (int i = 0; i < history.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {history[i]}");
                Console.WriteLine();
            }

            Console.WriteLine($"{ConsoleConstants.TotalFactsLabel} {history.Count}");
        }

        WaitForKey();
    }

    private async Task ShowStatisticsAsync()
    {
        Console.Clear();

        Console.WriteLine(ConsoleConstants.StatisticsTitle);
        Console.WriteLine();
        Console.WriteLine();

        var history = await _fileService.GetHistoryAsync();

        if (history.Count == 0)
        {
            Console.WriteLine(ConsoleConstants.NoFactsForStatistics);
        }
        else
        {
            var lengths = history
                .Select(line =>
                {
                    var parts = line.Split(ConsoleConstants.FactSeparator);
                    return int.Parse(parts[^1].Trim());
                })
                .ToList();

            var totalFacts = history.Count;
            var averageLength = lengths.Average();
            var shortestLength = lengths.Min();
            var longestLength = lengths.Max();

            Console.WriteLine($"{ConsoleConstants.TotalFactsLabel} {totalFacts}"); 
            Console.WriteLine($"{ConsoleConstants.AverageLengthLabel} {averageLength:F2}"); 
            Console.WriteLine($"{ConsoleConstants.ShortestFactLabel} {shortestLength}"); 
            Console.WriteLine($"{ConsoleConstants.LongestFactLabel} {longestLength}");
        }

        WaitForKey();
    }

    private async Task ClearHistoryAsync()
    {
        Console.Clear();

        Console.WriteLine(ConsoleConstants.ClearHistoryTitle); 
        Console.WriteLine(); 
        Console.WriteLine();

        var history = await _fileService.GetHistoryAsync();

        if (history.Count == 0)
        {
            Console.WriteLine(ConsoleConstants.HistoryAlreadyEmpty);
        }
        else
        {
            Console.WriteLine(string.Format(ConsoleConstants.DeleteConfirmation, history.Count)); 
            Console.WriteLine(); 
            Console.WriteLine(ConsoleConstants.YesOption); 
            Console.WriteLine(ConsoleConstants.NoOption);

            var key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.Y)
            {
                await _fileService.ClearHistoryAsync();

                Console.WriteLine();
                Console.WriteLine(ConsoleConstants.HistoryCleared);
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine(ConsoleConstants.OperationCancelled);
            }
        }

        WaitForKey();
    }

    private void WaitForKey()
    {
        Console.WriteLine();
        Console.WriteLine(ConsoleConstants.ReturnToMenu);
        Console.ReadKey(true);
    }
}