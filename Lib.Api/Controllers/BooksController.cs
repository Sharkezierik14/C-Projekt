namespace Library.Controllers
{
    using Lib.Api;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly LibContext _context;

        public BooksController(LibContext libraryContext)
        {
            _context = libraryContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> Get()
        {
            var books = await _context.Books.ToListAsync();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> Get(int id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book is null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Book book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }

            var existingBook = await _context.Books.FindAsync(id);

            if (existingBook is null)
            {
                return NotFound();
            }
            existingBook.Author = book.Author;
            existingBook.Title = book.Title;
            existingBook.Publisher = book.Publisher;
            existingBook.YearOfPublication = book.YearOfPublication;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingBook = await _context.Books.FindAsync(id);

            if (existingBook is null)
            {
                return NotFound();
            }
            _context.Books.Remove(existingBook);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
