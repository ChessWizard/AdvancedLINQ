using AdvancedLINQ.Shared.ResponseObjects;
using AdvancedLINQ.Shared.ResponseObjects.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdvancedLINQ.Controllers.Common
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        public IActionResult ActionResult<T>(IBaseResponse<T> response)
        {
            return new ObjectResult(response)
            {
                StatusCode = response.HttpStatusCode
            };
        }
    }
}
