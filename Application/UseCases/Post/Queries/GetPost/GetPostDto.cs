using dotnet_mediatr.Application.UseCases.Post.Models;
using dotnet_mediatr.Application.Models.Query;

namespace dotnet_mediatr.Application.UseCases.Post.Queries.GetPost  
{
    public class GetPostDto : BaseDto
    {
        public PostData Data { get; set; }
    }
}