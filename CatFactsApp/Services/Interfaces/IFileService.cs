namespace CatFactsApp.Services.Interfaces;

public interface IFileService
{
    Task AppendFactAsync(string fact, int length);

    Task<List<string>> GetHistoryAsync();

    Task ClearHistoryAsync();
}