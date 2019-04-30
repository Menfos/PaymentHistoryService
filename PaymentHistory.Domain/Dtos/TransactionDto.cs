using System;

namespace PaymentHistory.Domain.Dtos
{
    public class TransactionDto
    {
        public long TransactionId { get; set; }

        public DateTime TransactionDate { get; set; }

        public decimal Amount { get; set; }

        public string CurrencyCode { get; set; }

        public TransactionStatus Status { get; set; }
    }
}