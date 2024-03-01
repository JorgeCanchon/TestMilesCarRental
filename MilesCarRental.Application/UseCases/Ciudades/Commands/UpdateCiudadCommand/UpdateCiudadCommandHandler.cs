using MediatR;
using MilesCarRental.Application.Common.Interfaces;
using MilesCarRental.Application.Specifications.Ciudad;
using MilesCarRental.Application.Wrappers;
using MilesCarRental.Domain.Entities;

namespace MilesCarRental.Application.UseCases.Ciudades.Commands.UpdateCiudadCommand
{
    public class UpdateCiudadCommandHandler : IRequestHandler<UpdateCiudadCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Ciudad> _repositoryAsync;

        public UpdateCiudadCommandHandler(IRepositoryAsync<Ciudad> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync ?? throw new ArgumentNullException(nameof(repositoryAsync));
        }

        public async Task<Response<int>> Handle(UpdateCiudadCommand request, CancellationToken cancellationToken)
        {
            var ciudad = await _repositoryAsync.FirstOrDefaultAsync(new CiudadByIdSpecification(request.Id), cancellationToken);

            if (ciudad == null)
            {
                throw new KeyNotFoundException($"Registro no encontrado con el id {request.Id}");
            }

            ciudad.Nombre = request.Nombre;
            ciudad.PaisId = request.PaisId;

            await _repositoryAsync.UpdateAsync(ciudad);

            return new Response<int>(ciudad.Id);
        }
    }
}
