using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tests.Commands.CreateTest
{
    public class CreateTestCommandValidator: AbstractValidator<CreateTestCommand>
    {
        public CreateTestCommandValidator()
        {
            RuleFor(v => v.Title)
            .NotEmpty().WithMessage("Title is required.") 
            .MaximumLength(100).WithMessage("Title must not exceed 100 characters."); 


            RuleFor(v => v.Description)
                .NotEmpty().WithMessage("Description is required.") 
                .MaximumLength(500).WithMessage("Description must not exceed 500 characters."); 

          
            RuleFor(v => v.TimeLimit)
                .GreaterThan(0).WithMessage("TimeLimit must be greater than 0.") 
                .LessThanOrEqualTo(300).WithMessage("TimeLimit must not exceed 300 minutes."); 

 
            RuleFor(v => v.CourseId)
                .GreaterThan(0).WithMessage("CourseId must be greater than 0."); 

        }
    }
}
