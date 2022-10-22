using FluentValidation;

namespace Application.ValidationRules.FluentValidation.Brand
{
    public class BrandValidator : AbstractValidator<Domain.Models.Brand>
    {
        public BrandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("İsim alanı zorunludur.")
                .Length(1, 50)
                .WithMessage("Karakter uzunluğu 80'den fazla olamaz!");
        }
    }
}
