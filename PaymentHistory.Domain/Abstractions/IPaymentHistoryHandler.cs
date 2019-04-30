using System.Threading.Tasks;
using PaymentHistory.Domain.Dtos;

namespace PaymentHistory.Domain.Abstractions
{
    public interface IPaymentHistoryHandler
    {
        Task<CustomerPaymentsDto> GetPaymentHistoryAsync(CustomerInfoDto paymentHistoryDto);
    }
}