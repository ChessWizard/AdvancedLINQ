using AdvancedLINQ.Controllers.Common;
using AdvancedLINQ.Service.CQRS.Commands.CreateMedia;
using AdvancedLINQ.Service.CQRS.Queries.SearchMedias;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdvancedLINQ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediasController : BaseController
    {
        private readonly IMediator _mediator;

        public MediasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchMedias([FromQuery] SearchMediasQuery query)
        {
            var result = await _mediator.Send(query);
            return ActionResult(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateMedia([FromBody] CreateMediaCommand command)
        {
            var result = await _mediator.Send(command);
            return ActionResult(result);
        }
    }
}
