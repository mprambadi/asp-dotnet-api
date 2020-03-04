using System.Threading;
using System.Threading.Tasks;
using dotnet_mediatr.Application.Interfaces;
using dotnet_mediatr.Application.UseCases.Creator.Models;
using Microsoft.EntityFrameworkCore;
using dotnet_mediatr.Domain.Entity;
using MediatR;

namespace dotnet_mediatr.Application.UseCases.Creator.Command.CreateCreator
{
    public class CreateCreatorCommandHandler : IRequestHandler<CreateCreatorCommand, CreateCreatorCommandDto>
    {
        private readonly IBlogContext _context;

        public CreateCreatorCommandHandler(IBlogContext context)
        {
            _context = context;
        }
        public async Task<CreateCreatorCommandDto> Handle(CreateCreatorCommand request, CancellationToken cancellationToken)
        {

            var creator = new Domain.Entity.Creator
            {
                name = request.Data.Name,
                age = request.Data.Age
            };

            _context.Creators.Add(creator);
            await _context.SaveChangesAsync(cancellationToken);

            return new CreateCreatorCommandDto
            {
                Success = true,
                Message = "Creator successfully created",
            };

        }
    }
}