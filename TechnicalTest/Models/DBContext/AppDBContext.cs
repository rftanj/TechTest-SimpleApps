using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System;
using TechnicalTest.Models.DB;

namespace TechnicalTest.Models.DBContext
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions options): base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TransactionConfiguration());

            //modelBuilder.Entity<Transaction>()
            //    .HasKey(t => t.Id);

            //modelBuilder.Entity<Customer>()
            //    .HasKey(c => c.Id);

            //modelBuilder.Entity<Book>()
            //    .HasKey(b => b.Id);

            //modelBuilder.Entity<Transaction>()
            //    .HasOne(t => t.Customer)
            //    .WithMany(c => c.Transactions)
            //    .HasForeignKey(t => t.CustomerId);

            //modelBuilder.Entity<Transaction>()
            //    .HasOne(t => t.Book)
            //    .WithMany(b => b.Transactions)
            //    .HasForeignKey(t => t.BookId);

        }
    }
}
