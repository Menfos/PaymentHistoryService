using System.Collections.Generic;
using Newtonsoft.Json;

namespace PaymentHistory.API.Models
{
    public class PaymentHistoryResponse
    {
        [JsonProperty(PropertyName = "customerID")]
        public long CustomerId { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "mobile")]
        public string Mobile { get; set; }

        [JsonProperty(PropertyName = "transactions")]
        public IEnumerable<Transaction> Transactions { get; set; }
    }
}