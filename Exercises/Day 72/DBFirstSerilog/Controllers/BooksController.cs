using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DBFirstSerilog.Data;
using DBFirstSerilog.Models;
using Microsoft.Extensions.Logging;

namespace DBFirstSerilog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly AppDBContext _context;
        private readonly ILogger<BooksController> _logger;

        public BooksController(AppDBContext context, ILogger<BooksController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            _logger.LogInformation("Endpoint hit: GET /api/Books");
            return await _context.Books.Include(b => b.Author).ToListAsync();
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            _logger.LogInformation("Endpoint hit: GET /api/Books/{Id}", id);
            var book = await _context.Books.Include(b => b.Author).FirstOrDefaultAsync(b => b.Id == id);

            if (book == null)
            {
                _logger.LogWarning("Book with ID {Id} not found.", id);
                return NotFound();
            }

            return book;
        }

        // PUT: api/Books/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, Book book)
        {
            _logger.LogInformation("Endpoint hit: PUT /api/Books/{Id}", id);

            if (id != book.Id)
            {
                return BadRequest();
            }

            _context.Entry(book).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!BookExists(id))
                {
                    _logger.LogWarning("Attempted to update non-existent Book with ID {Id}.", id);
                    return NotFound();
                }
                else
                {
                    throw; // Let global middleware handle it
                }
            }

            return NoContent();
        }

        // POST: api/Books
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(Book book)
        {
            _logger.LogInformation("Endpoint hit: POST /api/Books");

            try
            {
                _context.Books.Add(book);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetBook", new { id = book.Id }, book);
            }
            catch (DbUpdateException ex)
            {
                if (BookExists(book.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw; // Let global middleware handle it
                }
            }
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            _logger.LogInformation("Endpoint hit: DELETE /api/Books/{Id}", id);

            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                _logger.LogWarning("Attempt to delete non-existent Book with ID {Id}.", id);
                return NotFound();
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.Id == id);
        }
    }
}