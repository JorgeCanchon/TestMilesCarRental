﻿using Microsoft.AspNetCore.Mvc;

namespace MilesCarRental.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class CiudadController : BaseApiController
    {
        [HttpGet()]
        public async Task<IActionResult> Get() =>
              Ok();
    }
}