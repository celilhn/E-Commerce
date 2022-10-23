using Application.ViewModels;
using FluentValidation;

namespace Application.ValidationRules.FluentValidation.User
{
    public class UserRegisterValidator : AbstractValidator<UserRegisterDto>
    {
        public UserRegisterValidator()
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
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("İsim alanı zorunludur.")
                .Length(1, 100)
                .WithMessage("Karakter uzunluğu 100'dan fazla olamaz!");
            RuleFor(x => x.RePassword)
                .NotEmpty()
                .WithMessage("Parola alanı zorunludur.")
                .Length(1, 10)
                .WithMessage("Karakter uzunluğu 10'dan fazla olamaz!");
            RuleFor(x => x.Surname)
                .NotEmpty()
                .WithMessage("Soyad alanı zorunludur.")
                .Length(1, 100)
                .WithMessage("Karakter uzunluğu 100'dan fazla olamaz!");
            RuleFor(x => new { x.Password, x.RePassword })
                .Must(x => x.Password == x.RePassword)
                .WithMessage("Parolalar eşit olmalıdır!");
        }
    }
}
