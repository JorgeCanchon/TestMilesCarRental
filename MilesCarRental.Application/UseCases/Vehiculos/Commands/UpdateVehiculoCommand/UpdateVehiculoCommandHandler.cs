using MediatR;
using MilesCarRental.Application.Common.Interfaces;
using MilesCarRental.Application.Specifications.Vehiculo;
using MilesCarRental.Application.Wrappers;
using MilesCarRental.Domain.Entities;

namespace MilesCarRental.Application.UseCases.Vehiculos.Commands.UpdateVehiculoCommand
{
    public class UpdateVehiculoCommandHandler : IRequestHandler<UpdateVehiculoCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Vehiculo> _repositoryAsync;

        public UpdateVehiculoCommandHandler(IRepositoryAsync<Vehiculo> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync ?? throw new ArgumentNullException(nameof(repositoryAsync));
        }

        public async Task<Response<int>> Handle(UpdateVehiculoCommand request, CancellationToken cancellationToken)
        {
            var vehiculo = await _repositoryAsync.FirstOrDefaultAsync(new VehiculoByIdSpecification(request.Id), cancellationToken);

            if (vehiculo == null)
            {
                throw new KeyNotFoundException($"Registro no encontrado con el id {request.Id}");
            }

            vehiculo.Marca = request.Marca;
            vehiculo.Placa = request.Placa;
            vehiculo.LocalidadDevolucionId = request.LocalidadDevolucionId;
            vehiculo.LocalidadRecogidaId = request.LocalidadRecogidaId;
            vehiculo.Disponible = request.Disponible;

            await _repositoryAsync.UpdateAsync(vehiculo);

            return new Response<int>(vehiculo.Id);
        }
    }
}
