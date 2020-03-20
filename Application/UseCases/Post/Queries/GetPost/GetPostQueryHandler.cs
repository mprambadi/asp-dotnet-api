using System.Threading;
using System.Threading.Tasks;
using dotnet_mediatr.Application.Interfaces;
using dotnet_mediatr.Application.UseCases.Post.Models;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace dotnet_mediatr.Application.UseCases.Post.Queries.GetPost
{
    public class GetPostQueryHandler : IRequestHandler<GetPostQuery, GetPostDto>
    {
        private readonly IBlogContext _context;

        public GetPostQueryHandler(IBlogContext context)
        {
            _context = context;
        }
        public async Task<GetPostDto> Handle(GetPostQuery request, CancellationToken cancellationToken)
        {

            var result = await _context.Posts.FirstOrDefaultAsync(e => e.id == request.id);

            return new GetPostDto
            {
                Success = true,
                Message = "Post successfully retrieved",
                Data = new PostData
                {
                    Title = result.title,
                    Body = result.body,
                }
            };

        }
    }
}