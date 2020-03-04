using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using dotnet_mediatr.Application.UseCases.Post.Queries.GetPost;

namespace dotnet_mediatr.Presenter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {

        private IMediator _mediatr;

        protected IMediator Mediator => _mediatr ?? (_mediatr = HttpContext.RequestServices.GetService<IMediator>());

        // GET: api/Post
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Post/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetPostDto>> Get(int id)
        {
            return Ok(await Mediator.Send(new GetPostQuery() { id = id }));
        }

        // POST: api/Post`
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Post/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
