using FluentValidation;

namespace dotnet_mediatr.Application.UseCases.Post.Queries.GetPost
{
    public class GetPostQueryValidator : AbstractValidator<GetPostQuery>
    {
        public GetPostQueryValidator()
        {
            RuleFor(x => x.id).GreaterThan(0).NotEmpty().WithMessage("Id harus terdaftar");
          
        }
    }
}