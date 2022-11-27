using Application.Interfaces;
using FluentValidation;

namespace Application.ValidationRules.FluentValidation.Size
{
    public class SizeValidator : AbstractValidator<Domain.Models.Size>
    {
        private readonly ISizeService sizeService;
        public SizeValidator(ISizeService sizeService)
        {
            this.sizeService = sizeService;
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("İsim alanı zorunludur.")
                .Length(1, 10)
                .WithMessage("Karakter uzunluğu 80'den fazla olamaz!");

            RuleFor(x => new { x.Name })
                .Must(x => !sizeService.IsSizeExist(x.Name))
                .When(x => x.Id == 0)
                .WithMessage("Aynı size'dan sadece bir adet kayıt edilebilir!");

            RuleFor(x => new { x.Id, x.Name })
                .Must(x => sizeService.ControlSizeIsExistWithParameters(x.Id, x.Name))
                .When(x => x.Id != 0)
                .WithMessage("Aynı size'dan sadece bir adet kayıt edilebilir!");
        }
    }
}
