namespace Lib.Api.Controllers
{
    using Contracts;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    [ApiController]
    [Route("[controller]")]
    public class RentalsController : ControllerBase
    {
        private readonly LibContext _context;

        public RentalsController(LibContext dbContext)
        {
            _context = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var rentals = await _context.Rentals
                .Include(r => r.Member)
                .Include(r => r.Book)
                .ToListAsync();

            return Ok(rentals);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var rental = await _context.Rentals
                .Include(r => r.Member)
                .Include(r => r.Book)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (rental == null)
            {
                return NotFound();
            }

            return Ok(rental);
        }

        [HttpPost]
        public async Task<IActionResult> Post(int memberId, int bookId, int days)
        {
            var member = await _context.Members.FirstOrDefaultAsync(m => m.Id == memberId);
            var book = await _context.Books.FirstOrDefaultAsync(b => b.Id == bookId);

            if (member == null || book == null)
            {
                return BadRequest("Invalid member or book ID.");
            }

            var rental = new Rental
            {
                MemberId = memberId,
                BookId = bookId,
                DateOfRental = DateTime.Now,
                ReturnDate = DateTime.Now.AddDays(days) // Assuming a 14-day rental period
            };

            _context.Rentals.Add(rental);
            await _context.SaveChangesAsync();

            return Ok(rental);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Rental updatedRental)
        {
            var rental = await _context.Rentals.FirstOrDefaultAsync(r => r.Id == id);

            if (rental == null)
            {
                return NotFound();
            }

            rental.DateOfRental = updatedRental.DateOfRental;
            rental.ReturnDate = updatedRental.ReturnDate;

            await _context.SaveChangesAsync();

            return Ok(rental);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var rental = await _context.Rentals.FirstOrDefaultAsync(r => r.Id == id);

            if (rental == null)
            {
                return NotFound();
            }

            _context.Rentals.Remove(rental);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
