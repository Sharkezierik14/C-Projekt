using Contracts;
using System.Net.Http.Json;

namespace LibrarianBlazor1.Services
{
    public class RentalServices : IRentalServices
    {
        private readonly HttpClient _httpClient;
        public RentalServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public Task<IEnumerable<Rental>?> GetAllRentalAsync() =>

        _httpClient.GetFromJsonAsync<IEnumerable<Rental>>("Rentals");

        public Task<Rental?> GetRentalByPersonId(int id) =>
            _httpClient.GetFromJsonAsync<Rental?>($"Rentals/{id}");
    }
}
