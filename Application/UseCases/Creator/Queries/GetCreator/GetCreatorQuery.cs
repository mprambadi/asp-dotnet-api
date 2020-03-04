using MediatR;

namespace dotnet_mediatr.Application.UseCases.Creator.Queries.GetCreator
{
    public class GetCreatorQuery: IRequest<GetCreatorDto>
    {
        public int id { get; set; }
    }
}