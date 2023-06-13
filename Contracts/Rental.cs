
namespace Contracts
{  
    public class Rental
    {
        public int Id { get; set; }

        public DateTime DateOfRental { get; set; }
        public DateTime ReturnDate { get; set; }
        public int MemberId { get; set; }
        virtual public Member Member { get; set; }
        public int BookId { get; set; }
        virtual public Book Book { get; set; }
    }
}
