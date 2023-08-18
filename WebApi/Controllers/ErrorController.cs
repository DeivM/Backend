
using Microsoft.AspNetCore.Mvc;
using WebApi.GlobalErrorHandling;

namespace WebApi.Controllers
{
    [Route("errors")]
    public class ErrorController : BaseApiController
    {
        /// <summary>
        /// ERRORES
        /// </summary>
        /// <param name="code">codigo de error</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Error(int code) {
            return new ObjectResult(new CodeErrorResponse(code));
        }

    }
}
