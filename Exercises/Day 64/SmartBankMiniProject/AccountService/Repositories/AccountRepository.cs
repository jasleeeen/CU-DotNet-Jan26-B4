using AccountService.Data;
using AccountService.Models;
using Microsoft.EntityFrameworkCore;

namespace AccountService.Repositories
{
    public class AccountRepository : IAccountRepository
        {
            private readonly AppDbContext _context;
            public AccountRepository(AppDbContext context)
            {
                _context = context;
            }

            public async Task<Account> AddAsync(Account account)
            {
                _context.Accounts.Add(account);
                await _context.SaveChangesAsync();
                return account;
            }

            public async Task<List<Account>> GetAllAsync()
            {
                return await _context.Accounts.ToListAsync();
            }

            public async Task<Account> GetByIdAsync(int id)
            {
                return await _context.Accounts.FindAsync(id);
            }

            public async Task UpdateAsync(Account account)
            {
                _context.Accounts.Update(account);
                await _context.SaveChangesAsync();
            }
    }
}
