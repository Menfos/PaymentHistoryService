using System.Threading.Tasks;
using PaymentHistory.DAL.Entities;

namespace PaymentHistory.DAL.Abstractions
{
    public interface IPaymentHistoryRepository
    {
        Task<CustomerEntity> GetPaymentHistoryByCustomerIdAsync(long customerId);

        Task<CustomerEntity> GetPaymentHistoryByCustomerEmailAsync(string email);
    }
}