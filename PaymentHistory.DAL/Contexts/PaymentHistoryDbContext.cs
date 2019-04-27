using Microsoft.EntityFrameworkCore;
using PaymentHistory.DAL.Entities;

namespace PaymentHistory.DAL.Contexts
{
    public class PaymentHistoryDbContext : DbContext
    {
        public DbSet<CustomerEntity> Customers { get; set; }

        public DbSet<TransactionEntity> Transactions { get; set; }

        public PaymentHistoryDbContext(DbContextOptions options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TransactionEntity>()
                .HasOne(transaction=> transaction.Customer)
                .WithMany(customer => customer.Transactions)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}