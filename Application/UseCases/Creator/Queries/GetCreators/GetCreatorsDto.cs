using System.Collections.Generic;
using dotnet_mediatr.Application.UseCases.Creator.Models;
using dotnet_mediatr.Application.Models.Query;

namespace dotnet_mediatr.Application.UseCases.Creator.Queries.GetCreators
{
    public class GetCreatorsDto : BaseDto
    {
        public IList<CreatorData> Data { get; set; }
    }
}