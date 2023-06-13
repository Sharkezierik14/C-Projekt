namespace Lib.Api.Controllers
{
    using Contracts;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    [ApiController]
    [Route("[controller]")]
    public class MembersController : ControllerBase
    {
        private readonly LibContext _context;

        public MembersController(LibContext context)
        {
            _context = context;
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) 
        {
            var existingMember = await _context.Members.FindAsync(id);
            if (existingMember is null) { return NotFound(); }
            _context.Members.Remove(existingMember);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Member>>> Get()
        {
            var members = await _context.Members.ToListAsync();
            return Ok(members);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Member>> Get(int id)
        {
            var member = await _context.Members.FindAsync(id);

            if (member is null)
            {
                return NotFound();
            }
            return Ok(member);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Member member)
        {
            _context.Members.Add(member);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Member member)
        {
            if (id != member.Id)
            {
                return BadRequest();
            }

            var existingMember = await _context.Members.FindAsync(id);

            if (existingMember is null)
            {
                return NotFound();
            }
            existingMember.Name = member.Name;
            existingMember.YearOfBirth = member.YearOfBirth;
            existingMember.Address = member.Address;
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
