using Contracts;


namespace LibrarianBlazor1.Services
{
    public interface IRentalServices
    {
        Task<IEnumerable<Rental>?> GetAllRentalAsync();

        Task<Rental?> GetRentalByRentalId(int id);

        Task<Rental?> AddRentalAsync(int bookId, int MemberId);

        Task DeleteRentalAsync(int id);

    }
}
