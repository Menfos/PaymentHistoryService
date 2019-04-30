using System.Collections.Generic;

namespace PaymentHistory.Domain.Dtos
{
    public class CustomerPaymentsDto
    {
        public long CustomerId { get; set; }

        public string CustomerName { get; set; }

        public string Email { get; set; }

        public long MobileNumber { get; set; }

        public IEnumerable<TransactionDto> Transactions { get; set; }
    }
}