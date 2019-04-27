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
    }
}