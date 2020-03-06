using System.Threading;
using System.Threading.Tasks;
using dotnet_mediatr.Application.Interfaces;
using dotnet_mediatr.Application.UseCases.Creator.Models;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Hangfire;
using System;
using dotnet_mediatr.Infrastructure.MailServices;
using Microsoft.Extensions.Logging;
namespace dotnet_mediatr.Application.UseCases.Creator.Command.CreateCreator
{
    public class CreateCreatorCommandHandler : IRequestHandler<CreateCreatorCommand, CreateCreatorCommandDto>
    {
        private readonly IBlogContext _context;
        private readonly IBackgroundJobClient _backgroundJob;

        public CreateCreatorCommandHandler(IBlogContext context, IBackgroundJobClient backgroundJob)
        {
            _context = context;
            _backgroundJob = backgroundJob;

        }
        public async Task<CreateCreatorCommandDto> Handle(CreateCreatorCommand request, CancellationToken cancellationToken)
        {

            var creator = new Domain.Entities.Creator
            {
                name = request.Data.Name,
                age = request.Data.Age
            };

            _context.Creators.Add(creator);
            _backgroundJob.Enqueue(() => Mail.Send());
            await _context.SaveChangesAsync(cancellationToken);

            return new CreateCreatorCommandDto
            {
                Success = true,
                Message = "Creator successfully created",
            };

        }
    }
}