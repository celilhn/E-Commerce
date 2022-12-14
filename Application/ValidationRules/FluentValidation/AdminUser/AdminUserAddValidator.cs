using Application.Interfaces;
using Application.Utilities;
using Application.ViewModels;
using FluentValidation;

namespace Application.ValidationRules.FluentValidation.AdminUser
{
    public class AdminUserAddValidator : AbstractValidator<AdminUserAddDto>
    {
        private readonly IUserService userService;
        public AdminUserAddValidator(IUserService userService)
        {
            this.userService = userService;
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

            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .WithMessage("Telefon numarası alanı zorunludur.");

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

            RuleFor(x => x.AdminUserType)
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

            RuleFor(x => new { x.PhoneNumber })
                .Must(x => AppUtilities.IsValidPhone(x.PhoneNumber))
                .WithMessage("Telefon numarası formatı doğru değil!");
            
            RuleFor(x => new { x.PhoneNumber })
                .Must(x => !userService.IsUserExistByPhoneNumber(x.PhoneNumber))
                .WithMessage("Lütfen farklı bir telefon numarası kullanınız!");

            RuleFor(x => new { x.Email })
                    .Must(x => !userService.IsUserExistByEmail(x.Email))
                .WithMessage("Lütfen farklı bir email kullanınız!");
        }
    }
}
