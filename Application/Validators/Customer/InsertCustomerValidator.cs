using Application.Dtos.Customer;
using Application.Shared.RegexPatterns;
using FluentValidation;

namespace Application.Validators.Customer;

public partial class InsertCustomerValidator : AbstractValidator<CustomerInsert>
{
    public InsertCustomerValidator()
    {
        //Name
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
        
        //Birthday
        RuleFor((x => x.Birthday))
            .NotEmpty().WithMessage("Birthday is required.")
            .Must(birthday =>
            {
                if (DateTime.TryParse((string?)birthday, out var parsedDate))
                {
                    return parsedDate <= DateTime.Today.AddYears(-18);
                }
                return false;
            }).WithMessage("You must be at least 18 years old and provide a valid date.");
        
        //Email and Phone
        
        RuleFor((x => x))    
            .Must(x => !string.IsNullOrWhiteSpace(x.Email) || !string.IsNullOrWhiteSpace(x.PhoneNumber))
            .WithMessage("You have to provide an Email or Phone number.");
        
        RuleFor(x => x.Email)
            .EmailAddress()
            .When(x => !string.IsNullOrWhiteSpace(x.Email))
            .WithMessage("Email provided is invalid.");

        RuleFor(x => x.PhoneNumber)
            .Matches(Regexes.DigitsOnly())
            .WithMessage("Phone number must be numeric.")
            .When(x => !string.IsNullOrWhiteSpace(x.PhoneNumber));

        RuleFor(x => x.PhoneNumber)
            .MinimumLength(8)
            .WithMessage("The phone number must be at least 8 characters long.")
            .When(x => !string.IsNullOrWhiteSpace(x.PhoneNumber));
    }
}