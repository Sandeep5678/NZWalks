using FluentValidation;
using FluentValidation.AspNetCore;

namespace NZWalks.API.Validators
{
    public class LoginRequestValidator: AbstractValidator<Models.DTO.LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(x => x.UserName)
            .NotEmpty().WithMessage("Username is required.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.");
        }
    }
}
