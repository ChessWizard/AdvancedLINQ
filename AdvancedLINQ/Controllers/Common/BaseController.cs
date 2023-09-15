using AdvancedLINQ.Shared.ResponseObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdvancedLINQ.Controllers.Common
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        public IActionResult ActionResult<T>(Response<T> response)
        {
            return new ObjectResult(response)
            {
                StatusCode = response.HttpStatusCode
            };
        }
    }
}
