using System;
using Microsoft.AspNetCore.Mvc.Filters;
using PaymentHistory.API.Models;

namespace PaymentHistory.API.ActionFilters
{
    public class PaymentHistoryRequestValidationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var isArgumentPresented = context.ActionArguments.TryGetValue("paymentHistoryRequest", out var paymentHistoryRequest);

            if (!isArgumentPresented || !(paymentHistoryRequest is PaymentHistoryRequest paymentHistoryRequestTyped))
            {
                throw new ArgumentException(
                    "Argument is missing in controller parameters or type is unexpected",
                    nameof(paymentHistoryRequest));
            }

            if (paymentHistoryRequestTyped.CustomerId == null && string.IsNullOrEmpty(paymentHistoryRequestTyped.Email))
            {
                context.ModelState.AddModelError(nameof(paymentHistoryRequest), "No inquiry criteria");
            }
        }
    }
}