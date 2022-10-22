using FluentValidation;

namespace Application.ValidationRules.FluentValidation.Size
{
    public class SizeValidator : AbstractValidator<Domain.Models.Size>
    {
        public SizeValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("İsim alanı zorunludur.")
                .Length(1, 10)
                .WithMessage("Karakter uzunluğu 80'den fazla olamaz!");
        }
    }
}
