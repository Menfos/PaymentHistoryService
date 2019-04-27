using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaymentHistory.DAL.Entities
{
    [Table("Transactions")]
    public class TransactionEntity
    {
        [Key]
        [Column("TransactionId")]
        public long TransactionId { get; set; }
        
        [Column("TransactionDate")]
        public DateTime TransactionDate { get; set; }
        
        [Column("Amount")]
        public decimal Amount { get; set; }

        [Column("CurrencyCode")]
        public string CurrencyCode { get; set; }

        [Column("Status")]
        public string Status { get; set; }

        public CustomerEntity Customer { get; set; }
    }
}