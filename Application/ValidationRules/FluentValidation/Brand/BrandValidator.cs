using Application.Interfaces;
using FluentValidation;

namespace Application.ValidationRules.FluentValidation.Brand
{
    public class BrandValidator : AbstractValidator<Domain.Models.Brand>
    {
        private readonly IBrandService brandService;
        public BrandValidator(IBrandService brandService)
        {
            this.brandService = brandService;
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("İsim alanı zorunludur.")
                .Length(1, 80)
                .WithMessage("Karakter uzunluğu 80'den fazla olamaz!");

            RuleFor(x => new { x.Name })
                .Must(x => !brandService.IsBrandExist(x.Name))
                .When(x => x.Id == 0)
                .WithMessage("Aynı markadan sadece bir adet kayıt edilebilir!");

            RuleFor(x => new { x.Id, x.Name })
                .Must(x => brandService.ControlBrandIsExistWithParameters(x.Id, x.Name) || !brandService.IsBrandExist(x.Name))
                .When(x => x.Id != 0)
                .WithMessage("Aynı markadan sadece bir adet kayıt edilebilir!");
        }
    }
}
