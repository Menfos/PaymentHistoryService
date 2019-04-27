using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PaymentHistory.DAL.Abstractions;
using PaymentHistory.DAL.Contexts;
using PaymentHistory.DAL.Entities;

namespace PaymentHistory.DAL.Repositories
{
    public class PaymentHistoryRepository : IPaymentHistoryRepository
    {
        private readonly PaymentHistoryDbContext paymentHistoryDbContext;

        public PaymentHistoryRepository(PaymentHistoryDbContext paymentHistoryDbContext)
        {
            this.paymentHistoryDbContext = paymentHistoryDbContext ?? throw new ArgumentNullException(nameof(paymentHistoryDbContext));
        }

        public Task<CustomerEntity> GetPaymentHistoryByCustomerIdAsync(long customerId)
        {

            return paymentHistoryDbContext.Customers
                .Include(entity => entity.Transactions)
                .FirstOrDefaultAsync(customer => customer.CustomerId.Equals(customerId));
        }

        public Task<CustomerEntity> GetPaymentHistoryByCustomerEmailAsync(string email)
        {
            return paymentHistoryDbContext.Customers
                .Include(entity => entity.Transactions)
                .FirstOrDefaultAsync(customer => customer.Email.Equals(email, StringComparison.InvariantCulture));
        }
    }
}