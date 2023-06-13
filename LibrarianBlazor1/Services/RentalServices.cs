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

        public Task<Rental?> AddRentalAsync(int bookId, int MemberId)
        {
            return null;
        }

        public Task<IEnumerable<Rental>?> GetAllRentalAsync() =>

        _httpClient.GetFromJsonAsync<IEnumerable<Rental>>("Rentals");

        public Task<Rental?> GetRentalByRentalId(int id) =>
            _httpClient.GetFromJsonAsync<Rental?>($"Rentals/{id}");

    }
}
