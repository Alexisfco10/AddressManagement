using Application.Dtos.Address;
using Application.Shared.RegexPatterns;
using FluentValidation;

namespace Application.Validators.Address;

public class InsertAddressValidator : AbstractValidator<AddressInsert>
{
    public InsertAddressValidator()
    {
        //ADDRESS LINE
        RuleFor(x => x.AddressLine).NotEmpty().WithMessage("Address Line is required");
        
        //COUNTRY
        RuleFor(x => x.Country).NotEmpty().WithMessage("Country is required");
        
        //STATE
        RuleFor(x => x.State).NotEmpty().WithMessage("State is required");
        
        //ZIP CODE
        RuleFor(x => x.ZipCode).NotEmpty().WithMessage("The zip code is required");
        RuleFor(x => x.ZipCode)
            .Matches(Regexes.ZipCode())
            .WithMessage("The zip code must be numeric.")
            .When(x => !string.IsNullOrWhiteSpace(x.ZipCode));
        
        //CUSTOMER
        RuleFor(x => x.CustomerId)
            .GreaterThan(0)
            .WithMessage("A valid customer is required");
    }
}