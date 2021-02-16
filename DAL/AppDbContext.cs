using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Horoscope> Horoscopes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Fluent API 
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
                .Property(u => u.Zodiac)
                .HasConversion<int>();
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Horoscope>()
                .Property(h => h.Zodiac)
                .HasConversion<int>();
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Horoscope>()
                .Property(h => h.Type)
                .HasConversion<int>();

        }
    }
}
