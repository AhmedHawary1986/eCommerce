using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UserService.Domain.DTO;
using UserService.Domain.Enums;

namespace UserService.Core.Validators
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters long.");
            RuleFor(x => x.PersonName)
                .NotEmpty().WithMessage("Person Name is required.")
                .MinimumLength(1).WithMessage("Person Name must be at least 1 characters long.")
                .MaximumLength(50).WithMessage("Person Name must be maximum 50 characters long.");


            RuleFor(x => x.Gender)
.NotEqual(GenderOptions.Unknown)
.WithMessage("Gender must be male or female");
        }
    }
}
