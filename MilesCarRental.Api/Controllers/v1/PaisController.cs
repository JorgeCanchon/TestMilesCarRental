using Microsoft.AspNetCore.Mvc;
using MilesCarRental.Application.UseCases.Paises.Commands.CreatePaisCommand;
using MilesCarRental.Application.UseCases.Paises.Commands.DeletePaisCommand;
using MilesCarRental.Application.UseCases.Paises.Commands.UpdatePaisCommand;
using MilesCarRental.Application.UseCases.Paises.Queries.GetAllPaises;
using MilesCarRental.Application.UseCases.Paises.Queries.GetPaisesById;

namespace MilesCarRental.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class PaisController : BaseApiController
    {
        [HttpGet()]
        public async Task<IActionResult> Get() =>
            Ok(await Mediator.Send(new GetAllPaisesQuery() { }));

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) =>
            Ok(await Mediator.Send(new GetPaisesByIdQuery() { Id = id }));

        [HttpPost]
        public async Task<IActionResult> Post(CreatePaisCommand command) =>
            Ok(await Mediator.Send(command));

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdatePaisCommand command)
        {
            if (id != command.Id)
                return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) =>
            Ok(await Mediator.Send(new DeletePaisCommand() { Id = id }));
    }
}
