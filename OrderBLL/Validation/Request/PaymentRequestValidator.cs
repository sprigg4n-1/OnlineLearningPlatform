using FluentValidation;
using OrderBLL.DTO.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderBLL.Validation.Request
{
    public class PaymentRequestValidator: AbstractValidator<PaymentRequest>
    {
        public PaymentRequestValidator()
        {
            RuleFor(payment => payment.Amount)
                .GreaterThan(0).WithMessage("Amount must be greater than 0.");

            RuleFor(payment => payment.PaymentMethod)
                .NotEmpty().WithMessage("Payment method is required.");

            RuleFor(payment => payment.Status)
                .NotEmpty().WithMessage("Status is required.")
                .Must(status => status == "Pending" || status == "Completed" || status == "Failed")
                .WithMessage("Status must be either 'Pending', 'Completed', or 'Failed'.");

            RuleFor(payment => payment.TransactionId)
                .NotEmpty().WithMessage("Transaction ID is required.")
                .Matches(@"^[A-Za-z0-9]+$").WithMessage("Transaction ID must be alphanumeric.");
        }
    }
}
