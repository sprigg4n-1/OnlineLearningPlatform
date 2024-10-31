using FluentValidation;
using OrderBLL.DTO.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderBLL.Validation.Request
{
    public class OrderRequestValidator: AbstractValidator<OrderRequest>
    {
        public OrderRequestValidator()
        {
            RuleFor(order => order.UserId)
                .GreaterThan(0).WithMessage("User ID must be greater than 0.");

            RuleFor(order => order.CourseId)
                .GreaterThan(0).WithMessage("Course ID must be greater than 0.");

            RuleFor(order => order.TotalPrice)
                .GreaterThan(0).WithMessage("Total Price must be greater than 0.");

            RuleFor(order => order.Status)
                .NotEmpty().WithMessage("Status is required.")
                .Must(status => status == "pending" || status == "completed" || status == "cancelled")
                .WithMessage("Status must be either 'Pending', 'Completed', or 'Cancelled'.");
        }
    }
}
