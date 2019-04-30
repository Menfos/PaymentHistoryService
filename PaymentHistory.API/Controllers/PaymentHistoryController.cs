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

        /// <summary>
        /// Get customers payment history
        /// </summary>
        /// <response code="200">OK</response>
        /// <response code="400">Bad Request</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal server error</response>
        [HttpGet]
        [ServiceFilter(typeof(PaymentHistoryRequestValidationAttribute))]
        [ProducesResponseType(typeof(PaymentHistoryResponse), 200)]
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
