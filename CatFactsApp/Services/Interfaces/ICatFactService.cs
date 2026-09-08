using CatFactsApp.Models;

namespace CatFactsApp.Services.Interfaces
{
    public interface ICatFactService
    {
        Task<CatFact> GetCatFactAsync();
    }
}
