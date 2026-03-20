using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LoanManagementAPI.Data;
using LoanManagementAPI.Models;
using LoanManagementAPI.DTOs;

namespace LoanManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        private readonly LoanManagementAPIContext _context;

        public LoansController(LoanManagementAPIContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadLoanDTO>>> GetLoans()
        {
            return await _context.Loan
                .Select(l => new ReadLoanDTO
                {
                    Id = l.Id,
                    BorrowerName = l.BorrowerName,
                    Amount = l.Amount,
                    LoanTermMonths = l.LoanTermMonths,
                    IsApproved = l.IsApproved
                })
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReadLoanDTO>> GetLoan(int id)
        {
            var loan = await _context.Loan.FindAsync(id);

            if (loan == null)
                return NotFound();

            return new ReadLoanDTO
            {
                Id = loan.Id,
                BorrowerName = loan.BorrowerName,
                Amount = loan.Amount,
                LoanTermMonths = loan.LoanTermMonths,
                IsApproved = loan.IsApproved
            };
        }

        [HttpPost]
        public async Task<ActionResult<ReadLoanDTO>> PostLoan(CreateLoanDTO dto)
        {
            var loan = new Loan
            {
                BorrowerName = dto.BorrowerName ?? "Unknown",
                Amount = dto.Amount ?? 0,
                LoanTermMonths = dto.LoanTermMonths,
                IsApproved = false
            };

            _context.Loan.Add(loan);
            await _context.SaveChangesAsync();

            var result = new ReadLoanDTO
            {
                Id = loan.Id,
                BorrowerName = loan.BorrowerName,
                Amount = loan.Amount,
                LoanTermMonths = loan.LoanTermMonths,
                IsApproved = loan.IsApproved
            };

            return CreatedAtAction(nameof(GetLoan), new { id = loan.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoan(int id, UpdateLoanDTO dto)
        {
            var loan = await _context.Loan.FindAsync(id);

            if (loan == null)
                return NotFound();

            loan.BorrowerName = dto.BorrowerName ?? loan.BorrowerName;
            loan.Amount = dto.Amount ?? loan.Amount;
            loan.LoanTermMonths = dto.LoanTermMonths;
            loan.IsApproved = dto.IsApproved;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteLoan(DeleteLoanDTO dto)
        {
            var loan = await _context.Loan.FindAsync(dto.Id);

            if (loan == null)
                return NotFound();

            _context.Loan.Remove(loan);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}