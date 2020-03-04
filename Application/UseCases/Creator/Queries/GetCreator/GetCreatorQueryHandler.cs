using System.Threading;
using System.Threading.Tasks;
using dotnet_mediatr.Application.Interfaces;
using dotnet_mediatr.Application.UseCases.Creator.Models;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace dotnet_mediatr.Application.UseCases.Creator.Queries.GetCreator
{
    public class GetCreatorQueryHandler : IRequestHandler<GetCreatorQuery, GetCreatorDto>
    {
        private readonly IBlogContext _context;

        public GetCreatorQueryHandler(IBlogContext context)
        {
            _context = context;
        }
        public async Task<GetCreatorDto> Handle(GetCreatorQuery request, CancellationToken cancellationToken)
        {

            var result = await _context.Creators.FirstOrDefaultAsync(e => e.id == request.id);

            return new GetCreatorDto
            {
                Success = true,
                Message = "Creator successfully retrieved",
                Data = new CreatorData
                {
                    Age = result.age,
                    Name = result.name,
                }
            };

        }
    }
}