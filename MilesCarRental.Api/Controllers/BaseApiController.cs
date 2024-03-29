﻿using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MilesCarRental.Api.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class BaseApiController : Controller
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}
