using CatFactsApp.Services.Interfaces;

namespace CatFactsApp.Services;

public class FileService : IFileService
{
    private readonly string _filePath;

    public FileService()
    {
        var documentsPath = Environment.GetFolderPath(
            Environment.SpecialFolder.MyDocuments);

        _filePath = Path.Combine(documentsPath, "catfacts.txt");
    }

    public async Task AppendFactAsync(string fact, int length)
    {
        var line = $"{fact} | {length}";

        await File.AppendAllTextAsync(
            _filePath,
            line + Environment.NewLine);
    }

    public async Task<List<string>> GetHistoryAsync()
    {
        if (!File.Exists(_filePath))
        {
            return new List<string>();
        }

        var lines = await File.ReadAllLinesAsync(_filePath);

        return lines.ToList();
    }

    public async Task ClearHistoryAsync()
    {
        if (File.Exists(_filePath))
        {
            await File.WriteAllTextAsync(_filePath, string.Empty);
        }
    }
}