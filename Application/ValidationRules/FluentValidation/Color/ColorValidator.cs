using Application.Interfaces;
using FluentValidation;

namespace Application.ValidationRules.FluentValidation.Color
{
    public class ColorValidator : AbstractValidator<Domain.Models.Color>
    {
        private readonly IColorService colorService;
        public ColorValidator(IColorService colorService)
        {
            this.colorService = colorService;
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Renk alanı zorunludur.")
                .Length(1, 100)
                .WithMessage("Karakter uzunluğu 100'den fazla olamaz!");

            RuleFor(x => new { x.Name })
                .Must(x => !colorService.IsColorExist(x.Name))
                .When(x => x.Id == 0)
                .WithMessage("Aynı renkten sadece bir adet kayıt edilebilir!");

            RuleFor(x => new { x.Id, x.Name })
                .Must(x => colorService.ControlColorIsExistWithParameters(x.Id, x.Name) || !colorService.IsColorExist(x.Name))
                .When(x => x.Id != 0)
                .WithMessage("Aynı renkten sadece bir adet kayıt edilebilir!");
        }
    }
}
