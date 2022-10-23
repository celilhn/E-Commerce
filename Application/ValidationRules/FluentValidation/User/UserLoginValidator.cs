using Application.ViewModels;
using FluentValidation;

namespace Application.ValidationRules.FluentValidation.User
{
    public class UserLoginValidator : AbstractValidator<UserLoginDto>
    {
        public UserLoginValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email alanı zorunludur.")
                .Length(1, 100)
                .WithMessage("Karakter uzunluğu 100'den fazla olamaz!");
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Parola alanı zorunludur.")
                .Length(1, 10)
                .WithMessage("Karakter uzunluğu 10'dan fazla olamaz!");
        }
    }
}
