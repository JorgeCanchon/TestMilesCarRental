using Microsoft.AspNetCore.Mvc;

namespace MilesCarRental.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class LocalidadController : BaseApiController
    {
        [HttpGet()]
        public async Task<IActionResult> Get() =>
                      Ok();
    }
}
