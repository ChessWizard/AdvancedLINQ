using AdvancedLINQ.Controllers.Common;
using AdvancedLINQ.Service.CQRS.Commands.CreateAlbum;
using AdvancedLINQ.Service.CQRS.Queries.GetAlbumById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AdvancedLINQ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsController : BaseController
    {
        private readonly IMediator _mediator;

        public AlbumsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromRoute] List<Guid> artistIds, [FromBody] CreateAlbumCommand command)
        {
            command.ArtistIds = artistIds;
            var result = await _mediator.Send(command);
            return ActionResult(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromRoute] Guid albumId)
        {
            var result = await _mediator.Send(new GetAlbumByIdQuery { AlbumId = albumId });
            return ActionResult(result);
        }
    }
}
