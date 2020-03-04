using MediatR;

namespace dotnet_mediatr.Application.UseCases.Post.Queries.GetPost
{
    public class GetPostQuery: IRequest<GetPostDto>
    {
        public int id { get; set; }
    }
}