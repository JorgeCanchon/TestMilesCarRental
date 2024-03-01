using Microsoft.AspNetCore.Mvc;
using MilesCarRental.Application.UseCases.Vehiculos.Commands.CreateVehiculoCommand;
using MilesCarRental.Application.UseCases.Vehiculos.Commands.DeleteVehiculoCommand;
using MilesCarRental.Application.UseCases.Vehiculos.Commands.UpdateVehiculoCommand;
using MilesCarRental.Application.UseCases.Vehiculos.Queries.GetAllVehiculos;
using MilesCarRental.Application.UseCases.Vehiculos.Queries.GetVehiculosAvailables;
using MilesCarRental.Application.UseCases.Vehiculos.Queries.GetVehiculosById;

namespace MilesCarRental.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class VehiculoController : BaseApiController
    {
        [HttpGet()]
        public async Task<IActionResult> Get() =>
                        Ok(await Mediator.Send(new GetAllVehiculosQuery() { }));

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) =>
            Ok(await Mediator.Send(new GetVehiculoByIdQuery() { Id = id }));

        [HttpGet("{localidadRecogidaId}/{localidadDevolucionId}")]
        public async Task<IActionResult> GetVehiculosAvaliables(int localidadRecogidaId, int localidadDevolucionId ) =>
            Ok(await Mediator.Send(new GetVehiculosAvailablesQuery() { LocalidadRecogidaId = localidadRecogidaId, 
                LocalidadDevolucionId = localidadDevolucionId
            }));

        [HttpPost]
        public async Task<IActionResult> Post(CreateVehiculoCommand command) =>
            Ok(await Mediator.Send(command));

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateVehiculoCommand command)
        {
            if (id != command.Id)
                return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) =>
            Ok(await Mediator.Send(new DeleteVehiculoCommand() { Id = id }));
    }
}
