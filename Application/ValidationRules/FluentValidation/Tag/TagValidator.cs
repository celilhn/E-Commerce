using Application.Interfaces;
using FluentValidation;

namespace Application.ValidationRules.FluentValidation.Tag
{
    public class TagValidator : AbstractValidator<Domain.Models.Tag>
    {
        private readonly ITagService tagService;
        public TagValidator(ITagService tagService)
        {
            this.tagService = tagService;
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("İsim alanı zorunludur.")
                .Length(1, 10)
                .WithMessage("Karakter uzunluğu 80'den fazla olamaz!");

            RuleFor(x => new { x.Name })
                .Must(x => !tagService.IsTagExist(x.Name))
                .When(x=> x.Id == 0)
                .WithMessage("Aynı tag'dan sadece bir adet kayıt edilebilir!");

            RuleFor(x => new { x.Id, x.Name })
                .Must(x => tagService.ControlTagIsExistWithParameters(x.Id, x.Name))
                .When(x => x.Id != 0)
                .WithMessage("Aynı tag'dan sadece bir adet kayıt edilebilir!");
        }
    }
}
