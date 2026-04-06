using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DBFirstSerilog.Data;
using DBFirstSerilog.Models;

namespace DBFirstSerilog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly AppDBContext _context;
        private readonly ILogger<AuthorsController> _logger;

        public AuthorsController(AppDBContext context, ILogger<AuthorsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/Authors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Author>>> GetAuthors()
        {
            _logger.LogInformation("Fetching authors from the database.");

            return await _context.Authors
                .Include(a => a.Books)
                .ToListAsync();
        }

        // GET: api/Authors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetAuthor(int id)
        {
            var author = await _context.Authors
                .Include(a => a.Books)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (author == null)
            {
                _logger.LogWarning("Author with ID {AuthorId} not found.", id);
                return NotFound();
            }

            _logger.LogInformation("Fetching author from the database.");
            return author;
        }

        // PUT: api/Authors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthor(int id, Author author)
        {
            if (id != author.Id)
            {
                return BadRequest();
            }

            _context.Update(author);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthorExists(id))
                {
                    _logger.LogWarning("Attempt to update non-existent Author with ID {AuthorId}.", id);
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            _logger.LogInformation("Updating author in the database.");
            return NoContent();
        }

        // POST: api/Authors
        [HttpPost]
        public async Task<ActionResult<Author>> PostAuthor(Author author)
        {
            _context.Authors.Add(author);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AuthorExists(author.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            _logger.LogInformation("Adding author in the database.");
            return CreatedAtAction("GetAuthor", new { id = author.Id }, author);
        }

        // DELETE: api/Authors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var author = await _context.Authors.FindAsync(id);

            if (author == null)
            {
                _logger.LogWarning("Attempt to delete non-existent Author with ID {AuthorId}.", id);
                return NotFound();
            }

            try
            {
                _context.Authors.Remove(author);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Deleting authors from the database.");
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting Author with ID {AuthorId}", id);
                return StatusCode(500, "Cannot delete author with existing books.");
            }
        }

        private bool AuthorExists(int id)
        {
            return _context.Authors.Any(e => e.Id == id);
        }
    }
}