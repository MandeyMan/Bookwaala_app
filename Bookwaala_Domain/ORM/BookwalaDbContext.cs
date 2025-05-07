using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookwaala_Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Bookwaala_Domain.ORM
{
    public class BookwalaDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookAssignment> BookAssignments { get; set; }
        public DbSet<LibraryCard> LibraryCards{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BookwalaDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Server=localhost;Database=BookwalaDb;User ID=postgres;Password=Prakash@123;Port=5432;");
            }
        }

    }
}
