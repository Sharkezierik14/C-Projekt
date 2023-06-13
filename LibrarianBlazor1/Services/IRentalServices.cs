using Contracts;


namespace LibrarianBlazor1.Services
{
    public interface IRentalServices
    {
        Task<IEnumerable<Rental>?> GetAllRentalAsync();

        Task<Rental?> GetRentalByPersonId(int id);

    }
}
