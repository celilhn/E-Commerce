using Application.Utilities;
using Application.ViewModels;
using FluentValidation;

namespace Application.ValidationRules.FluentValidation.User
{
    public class UserAddValidator : AbstractValidator<UserAddDto>
    {
        public UserAddValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("İsim alanı zorunludur.")
                .Length(1, 100)
                .WithMessage("İsim alanının karakter uzunluğu 100'den fazla olamaz!");
            
            RuleFor(x => x.Surname)
                .NotEmpty()
                .WithMessage("Soyad alanı zorunludur.")
                .Length(1, 100)
                .WithMessage("Soyad alanının karakter uzunluğu 100'den fazla olamaz!");
            
            RuleFor(x => x.UserName)
                .NotEmpty()
                .WithMessage("Kullanıcı adı alanı zorunludur.")
                .Length(1, 100)
                .WithMessage("Kullanıcı adı alanının karakter uzunluğu 100'den fazla olamaz!");
            
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email alanı zorunludur.")
                .Length(1, 100)
                .WithMessage("Email alanının karakter uzunluğu 100'den fazla olamaz!");
            
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Parola alanı zorunludur.")
                .Length(1, 10)
                .WithMessage("Parola alanının karakter uzunluğu 10'dan fazla olamaz!");
            
            RuleFor(x => x.UserType)
                .Must(x => (int)x >= 0)
                .WithMessage("Lütfen kullanıcı tipi seçiniz!");
            
            RuleFor(x => new { x.Password, x.RePassword })
                .Must(x => x.Password == x.RePassword)
                .WithMessage("Parolalar eşit olmalıdır!"); 
            
            RuleFor(x => new { x.Email })
                .Must(x => AppUtilities.IsValidEmail(x.Email))
                .WithMessage("Email formatı doğru değil!");

            RuleFor(x => new { x.Password })
                .Must(x => AppUtilities.ValidatePassword(x.Password))
                .WithMessage("Parola formatı doğru değil!");
        }
    }
}
