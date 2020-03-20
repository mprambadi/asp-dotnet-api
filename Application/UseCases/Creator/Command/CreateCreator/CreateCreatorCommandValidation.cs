using FluentValidation;

namespace dotnet_mediatr.Application.UseCases.Creator.Command.CreateCreator
{
    public class CreateCreatorCommandValidator : AbstractValidator<CreateCreatorCommand>
    {
        public CreateCreatorCommandValidator()
        {
            RuleFor(x => x.Data.Name)
                .NotEmpty()
                .WithMessage("Name harus diisi");
            
            RuleFor(x => x.Data.Age)
                .NotEmpty()
                .WithMessage("Age harus diisi");
        }
    }
}