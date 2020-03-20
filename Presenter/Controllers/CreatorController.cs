using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using dotnet_mediatr.Application.UseCases.Creator.Queries.GetCreator;
using dotnet_mediatr.Application.UseCases.Creator.Queries.GetCreators;
using dotnet_mediatr.Application.UseCases.Creator.Command.CreateCreator;

namespace dotnet_mediatr.Presenter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreatorController : ControllerBase
    {

        private IMediator _mediatr;

        protected IMediator Mediator => _mediatr ?? (_mediatr = HttpContext.RequestServices.GetService<IMediator>());
        public CreatorController()
        {

        }
        // GET: api/Creator
        [HttpGet]
        public async Task<ActionResult<GetCreatorsDto>> Get()
        {
            return Ok(await Mediator.Send(new GetCreatorsQuery(){}));
        }

        // GET: api/Creator/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetCreatorDto>> Get(int id)
        {

            return Ok(await Mediator.Send(new GetCreatorQuery() { id = id }));
        }

        // POST: api/Creator
        [HttpPost]
        public async Task<ActionResult<CreateCreatorCommandDto>> Post([FromBody] CreateCreatorCommand payload)
        {

            return Ok(await Mediator.Send(payload));
        }

        // PUT: api/Creator/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
