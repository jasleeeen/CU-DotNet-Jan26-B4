using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VagabondAPI.Models;

namespace VagabondAPI.Data
{
    public class VagabondAPIContext : DbContext
    {
        public VagabondAPIContext (DbContextOptions<VagabondAPIContext> options)
            : base(options)
        {
        }

        public DbSet<VagabondAPI.Models.Destination> Destinations { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Destination>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.ID).ValueGeneratedOnAdd();
                entity.Property(e => e.CityName).IsRequired();
                entity.Property(e => e.Country).IsRequired();
                entity.Property(e => e.Description).HasMaxLength(200);
                entity.Property(e => e.Rating).HasDefaultValue(3);
            });
        }
    }
}