using Application.Interfaces;
using FluentValidation;

namespace Application.ValidationRules.FluentValidation.Material
{
    public class MaterialValidator : AbstractValidator<Domain.Models.Material>
    {
        private readonly IMaterialService materialService;
        public MaterialValidator(IMaterialService materialService)
        {
            this.materialService = materialService;
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("İsim alanı zorunludur.")
                .Length(1, 80)
                .WithMessage("Materyal uzunluğu 80'den fazla olamaz!");

            RuleFor(x => new { x.Name })
                .Must(x => !materialService.IsMaterialExist(x.Name))
                .When(x => x.Id == 0)
                .WithMessage("Aynı materyalden sadece bir adet kayıt edilebilir!");

            RuleFor(x => new { x.Id, x.Name })
                .Must(x => materialService.ControlMaterialIsExistWithParameters(x.Id, x.Name) || !materialService.IsMaterialExist(x.Name))
                .When(x => x.Id != 0)
                .WithMessage("Aynı materyalden sadece bir adet kayıt edilebilir!");
        }
    }
}
