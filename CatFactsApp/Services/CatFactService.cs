using CatFactsApp.Models;
using System.Net.Http.Json;

namespace CatFactsApp.Services
{
    public class CatFactService : ICatFactService
    {
        private readonly HttpClient _httpClient;

        public CatFactService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CatFact> GetCatFactAsync()
        {
            var catFact = await _httpClient.GetFromJsonAsync<CatFact>(
                "https://catfact.ninja/fact");

            return catFact ?? throw new Exception("Nie udało się pobrać danych.");
        }
    }
}
