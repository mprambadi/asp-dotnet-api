using dotnet_mediatr.Application.UseCases.Creator.Models;
using dotnet_mediatr.Application.Models.Query;

namespace dotnet_mediatr.Application.UseCases.Creator.Queries.GetCreator
{
    public class GetCreatorDto : BaseDto
    {
        public CreatorData Data { get; set; }
    }
}