using Contracts;

namespace LibrarianBlazor1.Services
{
    public interface IPersonServices
    {
        Task<IEnumerable<Member>?> GetAllPeopleAsync();
        Task<Member?> GetPersonByIdAsync(int id);

        Task UpdatePersonAsync(int id, Member member);
        Task DeletePersonAsync(int id);

        Task AddpersonAsync(Member member);
    }
}
