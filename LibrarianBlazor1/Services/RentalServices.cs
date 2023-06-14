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

        public async Task<Rental?> AddRentalAsync(int bookId, int memberId)
        {
            var requestUri = $"Rentals?bookId={bookId}&memberId={memberId}";
            var response = await _httpClient.PostAsync(requestUri, null);

            if (response.IsSuccessStatusCode)
            {
                var createdRental = await response.Content.ReadFromJsonAsync<Rental>();
                return createdRental;
            }
            else
            {
                // Kölcsönzés létrehozása sikertelen
                return null;
            }
        }

        public Task<IEnumerable<Rental>?> GetAllRentalAsync() =>

        _httpClient.GetFromJsonAsync<IEnumerable<Rental>>("Rentals");

        public Task<Rental?> GetRentalByRentalId(int id) =>
            _httpClient.GetFromJsonAsync<Rental?>($"Rentals/{id}");

    }
}
