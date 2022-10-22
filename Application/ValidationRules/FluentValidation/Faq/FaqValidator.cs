using FluentValidation;

namespace Application.ValidationRules.FluentValidation.Faq
{
    public class FaqValidator : AbstractValidator<Domain.Models.Faq>
    {
        public FaqValidator()
        {
            RuleFor(x => x.Question)
                .NotEmpty()
                .WithMessage("Soru alanı zorunludur.")
                .Length(1, 1500)
                .WithMessage("Karakter uzunluğu 1500'den fazla olamaz!");
            RuleFor(x => x.Answer)
                .NotEmpty()
                .WithMessage("Cevap alanı zorunludur.")
                .Length(1, 1500)
                .WithMessage("Karakter uzunluğu 1500'den fazla olamaz!");
        }
    }
}
