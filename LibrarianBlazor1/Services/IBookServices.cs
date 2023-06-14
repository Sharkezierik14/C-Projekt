using Contracts;

namespace LibrarianBlazor1.Services
{
    public interface IBookServices
    {
        Task<IEnumerable<Book>?> GetAllBookAsync();

        Task<Book?> GetBookByIdAsync(int id);
        
    }
}
