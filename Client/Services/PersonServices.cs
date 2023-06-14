using Contracts;
using System.Net.Http.Json;

namespace Client.Services
{
    public class PersonServices : IPersonServices
    {   

        private readonly HttpClient _httpClient;
        public PersonServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public Task<IEnumerable<Member>?> GetAllPeopleAsync() => 
            
            _httpClient.GetFromJsonAsync<IEnumerable<Member>>("Members");

        public Task<Member?> GetPersonByIdAsync(int id) =>
            _httpClient.GetFromJsonAsync<Member?>($"Members/{id}");

        public async Task UpdatePersonAsync(int id, Member member) =>
            await _httpClient.PutAsJsonAsync($"Members/{id}",member);

        public async Task DeletePersonAsync(int id) =>  
            await _httpClient.DeleteAsync($"Members/{id}");

        public async Task AddpersonAsync(Member member) =>
            await _httpClient.PostAsJsonAsync("Members", member);
       
    }

}
    
