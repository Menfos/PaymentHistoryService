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

        [Required]
        [Column("TransactionDate")]
        public DateTime TransactionDate { get; set; }

        [Required]
        [Column("Amount")]
        public decimal Amount { get; set; }

        [Required]
        [MaxLength(3)]
        [Column("CurrencyCode")]
        public string CurrencyCode { get; set; }

        [Required]
        [MaxLength(15)]
        [Column("Status")]
        public string Status { get; set; }
    }
}