using Microsoft.AspNetCore.Mvc;
using MilesCarRental.Application.UseCases.Ciudades.Commands.CreateCiudadCommand;
using MilesCarRental.Application.UseCases.Ciudades.Commands.DeleteCiudadCommand;
using MilesCarRental.Application.UseCases.Ciudades.Commands.UpdateCiudadCommand;
using MilesCarRental.Application.UseCases.Ciudades.Queries.GetAllCiudades;
using MilesCarRental.Application.UseCases.Ciudades.Queries.GetAllCiudadesById;

namespace MilesCarRental.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class CiudadController : BaseApiController
    {
        [HttpGet()]
        public async Task<IActionResult> Get() =>
                  Ok(await Mediator.Send(new GetAllCiudadesQuery() { }));

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) =>
            Ok(await Mediator.Send(new GetAllCiudadesByIdQuery() { Id = id }));

        [HttpPost]
        public async Task<IActionResult> Post(CreateCiudadCommand command) =>
            Ok(await Mediator.Send(command));

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateCiudadCommand command)
        {
            if (id != command.Id)
                return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) =>
            Ok(await Mediator.Send(new DeleteCiudadCommand() { Id = id }));
    }
}
