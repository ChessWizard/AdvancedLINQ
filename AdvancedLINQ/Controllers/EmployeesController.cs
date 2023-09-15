using AdvancedLINQ.Controllers.Common;
using AdvancedLINQ.Service.CQRS.Queries.GetSuccessfulEmployees;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdvancedLINQ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : BaseController
    {
        private readonly IMediator _mediator;

        public EmployeesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetSuccessfulEmployees([FromQuery] GetSuccessfulEmployeesQuery query)
        {
            var result = await _mediator.Send(query);
            return ActionResult(result);
        }
    }
}
