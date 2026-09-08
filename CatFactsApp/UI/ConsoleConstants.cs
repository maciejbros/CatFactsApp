namespace CatFactsApp.UI;

public static class ConsoleConstants
{
    public const string AppTitle = "      CAT FACTS";

    public const string GetNewFactOption = "[ENTER] Get new cat fact";
    public const string HistoryOption = "[H]     Show history";
    public const string StatisticsOption = "[S]     Show statistics";
    public const string ClearHistoryOption = "[C]     Clear history";
    public const string ExitOption = "[ESC]   Exit";

    public const string FactTitle = "      CAT FACTS";
    public const string HistoryTitle = "       HISTORY";
    public const string StatisticsTitle = "      STATISTICS";
    public const string ClearHistoryTitle = "     CLEAR HISTORY";

    public const char FactSeparator = '|';

    public const string NoFactsFound = "No facts found.";
    public const string NoFactsForStatistics =
        "No facts available for statistics.";

    public const string HistoryAlreadyEmpty =
        "History is already empty.";

    public const string FactSaved =
        "Fact saved successfully.";

    public const string HistoryCleared =
        "History cleared successfully.";

    public const string OperationCancelled =
        "Operation cancelled.";

    public const string YesOption = "[Y] Yes";
    public const string NoOption = "[N] No";

    public const string ReturnToMenu =
        "Press any key to return to the menu...";

    public const string FactLabel = "Fact:";
    public const string LengthLabel = "Length:";

    public const string TotalFactsLabel = "Total facts:";
    public const string AverageLengthLabel = "Average length:";
    public const string ShortestFactLabel = "Shortest fact:";
    public const string LongestFactLabel = "Longest fact:";

    public const string ErrorMessage = "An error occurred: {0}";
    public const string DeleteConfirmation =
        "Are you sure you want to delete {0} facts?";
}