using MediatR;
using MilesCarRental.Application.Common.Interfaces;
using MilesCarRental.Application.Specifications.Vehiculo;
using MilesCarRental.Application.Wrappers;
using MilesCarRental.Domain.Entities;

namespace MilesCarRental.Application.UseCases.Vehiculos.Commands.DeleteVehiculoCommand
{
    public class DeleteVehiculoCommandHandler : IRequestHandler<DeleteVehiculoCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Vehiculo> _repositoryAsync;

        public DeleteVehiculoCommandHandler(IRepositoryAsync<Vehiculo> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync ?? throw new ArgumentNullException(nameof(repositoryAsync));
        }

        public async Task<Response<int>> Handle(DeleteVehiculoCommand request, CancellationToken cancellationToken)
        {
            var vehiculo = await _repositoryAsync.FirstOrDefaultAsync(new VehiculoByIdSpecification(request.Id));

            if (vehiculo == null)
            {
                throw new KeyNotFoundException($"Registro no encontrado con el id {request.Id}");
            }

            await _repositoryAsync.DeleteAsync(vehiculo);

            return new Response<int>(vehiculo.Id);
        }
    }
}
