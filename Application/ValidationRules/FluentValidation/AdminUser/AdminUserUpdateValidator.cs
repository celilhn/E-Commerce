﻿using Application.Utilities;
using Application.ViewModels;
using FluentValidation;

namespace Application.ValidationRules.FluentValidation.AdminUser
{
    public class AdminUserUpdateValidator : AbstractValidator<AdminUserUpdateDto>
    {
        public AdminUserUpdateValidator()
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

            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .WithMessage("Telefon numarası alanı zorunludur.");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email alanı zorunludur.")
                .Length(1, 100)
                .WithMessage("Email alanının karakter uzunluğu 100'den fazla olamaz!");

            RuleFor(x => x.AdminUserType)
                .Must(x => (int)x >= 0)
                .WithMessage("Lütfen kullanıcı tipi seçiniz!");

            RuleFor(x => x.Status)
                .Must(x => (int)x >= 0)
                .WithMessage("Lütfen status tipi seçiniz!");

            RuleFor(x => new { x.Email })
                .Must(x => AppUtilities.IsValidEmail(x.Email))
                .WithMessage("Email formatı doğru değil!");

            RuleFor(x => new { x.PhoneNumber })
                .Must(x => AppUtilities.IsValidPhone(x.PhoneNumber))
                .WithMessage("Telefon numarası formatı doğru değil!");
        }
    }
}