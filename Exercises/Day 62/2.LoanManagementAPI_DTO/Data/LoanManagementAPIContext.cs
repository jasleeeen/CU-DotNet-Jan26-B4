using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LoanManagementAPI.Models;

namespace LoanManagementAPI.Data
{
    public class LoanManagementAPIContext : DbContext
    {
        public LoanManagementAPIContext (DbContextOptions<LoanManagementAPIContext> options)
            : base(options)
        {
        }

        public DbSet<LoanManagementAPI.Models.Loan> Loan { get; set; } = default!;
    }
}
