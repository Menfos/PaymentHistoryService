using System.ComponentModel.DataAnnotations;

namespace PaymentHistory.API.Models
{
    public class PaymentHistoryRequest
    {
        [Range(0, 9999999999, ErrorMessage = "CustomerId parameter should be less than 10 digits")]
        public long? CustomerId { get; set; }

        [MaxLength(25, ErrorMessage = "'Email' parameter should be less than 25 digits")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }
    }
}