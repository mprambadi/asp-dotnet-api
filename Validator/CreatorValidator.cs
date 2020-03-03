using FluentValidation;
using dotnet_mediatr.Entity;
namespace dotnet_mediatr.Validators
{
    public class CreatorValidator : AbstractValidator<Creator>
    {
        public CreatorValidator()
        {
            RuleFor(x => x.name).NotEmpty().WithMessage("nama tidak boleh kosong");
            RuleFor(x => x.age).NotEmpty().WithMessage("age tidak boleh kosong");
        }
    }
}