using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PaymentHistory.API.ActionFilters;
using PaymentHistory.API.Models;
using PaymentHistory.Domain.Abstractions;
using PaymentHistory.Domain.Dtos;

namespace PaymentHistory.API.Controllers
{
    [ApiController]
    [Route("api/v1/payment/history")]
    public class PaymentHistoryController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IPaymentHistoryHandler paymentHistoryHandler;

        public PaymentHistoryController(IMapper mapper, IPaymentHistoryHandler paymentHistoryHandler)
        {
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.paymentHistoryHandler = paymentHistoryHandler ?? throw new ArgumentNullException(nameof(paymentHistoryHandler));
        }

        [HttpGet]
        [ServiceFilter(typeof(PaymentHistoryRequestValidationAttribute))]
        public async Task<IActionResult> Get([FromQuery]PaymentHistoryRequest paymentHistoryRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var customerInfo = mapper.Map<CustomerInfoDto>(paymentHistoryRequest);
            var customerPayments = await paymentHistoryHandler.GetPaymentHistoryAsync(customerInfo);

            if (customerPayments == null)
                return NotFound();

            var paymentHistoryResponse = mapper.Map<PaymentHistoryResponse>(customerPayments);
            return Ok(paymentHistoryResponse);
        }
    }
}
