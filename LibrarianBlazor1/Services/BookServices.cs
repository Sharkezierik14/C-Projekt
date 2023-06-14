using Contracts;
using System.Net.Http.Json;

namespace LibrarianBlazor1.Services
{
    public class BookServices : IBookServices
    {   
  

        private readonly HttpClient _httpClient;
        public BookServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public Task<IEnumerable<Book>?> GetAllBookAsync() => _httpClient.GetFromJsonAsync<IEnumerable<Book>>("Books");

        public Task<Book?> GetBookByIdAsync(int id) => _httpClient.GetFromJsonAsync<Book?>($"Books/{id}");

    }
}
