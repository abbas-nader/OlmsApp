using FluentValidation;
using OlmsApp.DTOs;

namespace OlmsApp.Validators;

public class CreatePatientDtoValidator: AbstractValidator<CreatePatientDto>
{
    public CreatePatientDtoValidator()
    {
        RuleFor(x=> x.FirstName)
            .NotEmpty().WithMessage("First name is required")
            .MinimumLength(2).WithMessage("First name must be at least 2 characters long")
            .MaximumLength(50).WithMessage("First name cannot exceed 50 characters");
        RuleFor(y => y.LastName)
            .NotEmpty().WithMessage("Last name is required")
            .MinimumLength(2).WithMessage("Last name must be at least 2 characters long")
            .MaximumLength(50).WithMessage("Last name cannot exceed 50 characters");
        RuleFor(x=> x.NationalCode)
            .NotEmpty().WithMessage("National code is required")
            .Matches(@"^\d{10}$").WithMessage("National code must be 10 digits");
        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("Phone number is required")
            .Matches(@"^09\d{9}$").WithMessage("Phone number must be 11 digits");

    }
}