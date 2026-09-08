namespace CatFactsApp.Services;

public interface IFileService
{
    Task AppendFactAsync(string fact, int length);

    Task<List<string>> GetHistoryAsync();

    Task ClearHistoryAsync();
}