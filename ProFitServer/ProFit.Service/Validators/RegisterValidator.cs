using FluentValidation;
using ProFit.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProFit.Service.Validators
{
    class RegisterValidator:AbstractValidator<UserDTO>
    {
        public RegisterValidator()
        {
            RuleFor(user => user.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(user => user.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters long.");

            RuleFor(user => user.Name)
                .NotEmpty().WithMessage("Name is required.");
        }
    }
}
