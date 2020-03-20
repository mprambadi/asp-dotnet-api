using FluentValidation;
using dotnet_mediatr.Application.UseCases.Creator.Models;

namespace dotnet_mediatr.Application.UseCases.Creator.Queries.GetCreator
{
    public class GetCreatorValidator : AbstractValidator<GetCreatorQuery>
    {
        public GetCreatorValidator()
        {
            RuleFor(x => x.id).GreaterThan(0).NotEmpty().WithMessage("Id harus terdaftar");
          
        }
    }
}