using Microsoft.AspNetCore.Mvc;
using MilesCarRental.Application.UseCases.Localidades.Commands.CreateLocalidadCommand;
using MilesCarRental.Application.UseCases.Localidades.Commands.DeleteLocalidadCommand;
using MilesCarRental.Application.UseCases.Localidades.Commands.UpdateLocalidadCommand;
using MilesCarRental.Application.UseCases.Localidades.Queries.GetAllLocalidades;
using MilesCarRental.Application.UseCases.Localidades.Queries.GetLocalidadById;

namespace MilesCarRental.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class LocalidadController : BaseApiController
    {
        [HttpGet()]
        public async Task<IActionResult> Get() =>
                          Ok(await Mediator.Send(new GetAllLocalidadesQuery() { }));

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) =>
            Ok(await Mediator.Send(new GetLocalidadByIdQuery() { Id = id }));

        [HttpPost]
        public async Task<IActionResult> Post(CreateLocalidadCommand command) =>
            Ok(await Mediator.Send(command));

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateLocalidadCommand command)
        {
            if (id != command.Id)
                return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) =>
            Ok(await Mediator.Send(new DeleteLocalidadCommand() { Id = id }));
    }
}
