using System;
using System.Threading.Tasks;
using AutoMapper;
using PaymentHistory.DAL.Abstractions;
using PaymentHistory.DAL.Entities;
using PaymentHistory.Domain.Abstractions;
using PaymentHistory.Domain.Dtos;

namespace PaymentHistory.Domain.Handlers
{
    public class PaymentHistoryHandler : IPaymentHistoryHandler
    {
        private readonly IPaymentHistoryRepository paymentHistoryRepository;
        private readonly IMapper mapper;

        public PaymentHistoryHandler(IPaymentHistoryRepository paymentHistoryRepository, IMapper mapper)
        {
            this.paymentHistoryRepository = paymentHistoryRepository ?? throw new ArgumentNullException(nameof(paymentHistoryRepository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<CustomerPaymentsDto> GetPaymentHistoryAsync(CustomerInfoDto paymentHistoryDto)
        {
            var customerEntity = await RetrieveCustomerEntity(paymentHistoryDto).ConfigureAwait(false);

            return mapper.Map<CustomerPaymentsDto>(customerEntity);
        }

        private Task<CustomerEntity> RetrieveCustomerEntity(CustomerInfoDto paymentHistoryDto)
        {
            if (paymentHistoryDto.CustomerId.HasValue)
            {
                return paymentHistoryRepository
                    .GetPaymentHistoryByCustomerIdAsync(paymentHistoryDto.CustomerId.Value);
            }

            if (!string.IsNullOrEmpty(paymentHistoryDto.Email))
            {
                return paymentHistoryRepository
                    .GetPaymentHistoryByCustomerEmailAsync(paymentHistoryDto.Email);
            }

            throw new NotSupportedException($"Not supported flow for provided values in {nameof(paymentHistoryDto)}");
        }
    }
}