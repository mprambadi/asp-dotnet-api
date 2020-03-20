using MediatR;

namespace dotnet_mediatr.Application.UseCases.Creator.Command.CreateCreator
{
    public class CreateCreatorCommand : IRequest<CreateCreatorCommandDto>
    {
        public CreateCreatorData Data { get; set; }
    }

    public class CreateCreatorData
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}