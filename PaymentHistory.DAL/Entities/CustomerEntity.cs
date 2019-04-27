using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaymentHistory.DAL.Entities
{
    [Table("Customers")]
    public class CustomerEntity
    {
        [Key]
        [Column("CustomerId")]
        public long CustomerId { get; set; }

        [MaxLength(30)]
        [Column("CustomerName")]
        public string CustomerName { get; set; }

        [MaxLength(25)]
        [Column("Email")]
        public string Email { get; set; }

        [Column("MobileNumber")]
        public long MobileNumber { get; set; }
    }
}