using MediatR;
using Microsoft.AspNetCore.Mvc;
using MilesCarRental.Application.UseCases.Ciudades.Commands.CreateCiudadCommand;
using MilesCarRental.Application.UseCases.Localidades.Commands.CreateLocalidadCommand;
using MilesCarRental.Application.UseCases.Paises.Commands.CreatePaisCommand;
using MilesCarRental.Application.UseCases.Vehiculos.Commands.CreateVehiculoCommand;
using MilesCarRental.Application.Wrappers;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MilesCarRental.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ApiDataTestController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> Post()
        {
            var paisCommand = new CreatePaisCommand() { Nombre = "Colombia" };

            var bogota = new CreateCiudadCommand() { Nombre = "Bogota", PaisId = 1 };
            var medellin = new CreateCiudadCommand() { Nombre = "Medellin", PaisId = 1 };

            var aeropuertoDorado = new CreateLocalidadCommand() { Nombre = "Aeropuerto El Dorado", Direccion = "", CiudadId = 1 };
            var aeropuertoOlaya = new CreateLocalidadCommand() { Nombre = "Aeropuerto Olaya Herrea", Direccion = "", CiudadId = 2 };
            var exitoLa70 = new CreateLocalidadCommand() { Nombre = "Exito la 70", Direccion = "", CiudadId = 2 };
            var ccSantafe = new CreateLocalidadCommand() { Nombre = "Medellin", Direccion = "", CiudadId = 1 };

            var logan = new CreateVehiculoCommand() { Marca = "Renault", Placa = "AAA123", LocalidadDevolucionId = 1, LocalidadRecogidaId = 1, Disponible = true };
            var nissan = new CreateVehiculoCommand() { Marca = "Nissan", Placa = "BBB123", LocalidadDevolucionId = 2, LocalidadRecogidaId = 2, Disponible = true };
            var chevrolet = new CreateVehiculoCommand() { Marca = "Chevrolet", Placa = "CCC123", LocalidadDevolucionId = 1, LocalidadRecogidaId = 2, Disponible = true };

            var array = new IRequest<Response<int>>[]{ paisCommand, bogota, medellin, aeropuertoDorado, aeropuertoOlaya,
                exitoLa70, ccSantafe, logan, nissan, chevrolet
            };

            array.ToList().ForEach(item =>
            {
                Mediator.Send(item).GetAwaiter().GetResult();
            });
          
            return Ok();
        }
    }
}
