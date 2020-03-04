using System.Threading;
using System.Threading.Tasks;
using dotnet_mediatr.Application.Interfaces;
using dotnet_mediatr.Application.UseCases.Creator.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using MediatR;

namespace dotnet_mediatr.Application.UseCases.Creator.Queries.GetCreators
{
    public class GetCreatorsQueryHandler : IRequestHandler<GetCreatorsQuery, GetCreatorsDto>
    {
        private readonly IBlogContext _context;

        public GetCreatorsQueryHandler(IBlogContext context)
        {
            _context = context;
        }
        public async Task<GetCreatorsDto> Handle(GetCreatorsQuery request, CancellationToken cancellationToken)
        {

            var data = await _context.Creators.ToListAsync();

            var result = data.Select(e => new CreatorData
            {
                Name = e.name,
                Age = e.age,
            });

            return new GetCreatorsDto
            {
                Success = true,
                Message = "Creator successfully retrieved",
                Data = result.ToList()
            };

        }
    }
}