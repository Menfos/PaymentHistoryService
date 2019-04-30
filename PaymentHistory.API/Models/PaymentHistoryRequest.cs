using System.ComponentModel.DataAnnotations;

namespace PaymentHistory.API.Models
{
    public class PaymentHistoryRequest
    {
        [MaxLength(10, ErrorMessage = "'customerId' parameter should be less than 10 digits")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Invalid Customer ID")]
        public string CustomerId { get; set; }

        [MaxLength(25, ErrorMessage = "'Email' parameter should be less than 25 digits")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }
    }
}