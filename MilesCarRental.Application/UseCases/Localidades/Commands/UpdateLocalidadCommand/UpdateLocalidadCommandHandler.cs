using MediatR;
using MilesCarRental.Application.Common.Interfaces;
using MilesCarRental.Application.Specifications.Localidad;
using MilesCarRental.Application.Wrappers;
using MilesCarRental.Domain.Entities;

namespace MilesCarRental.Application.UseCases.Localidades.Commands.UpdateLocalidadCommand
{
    public class UpdateLocalidadCommandHandler : IRequestHandler<UpdateLocalidadCommand, Response<int>>
    {

        private readonly IRepositoryAsync<Localidad> _repositoryAsync;

        public UpdateLocalidadCommandHandler(IRepositoryAsync<Localidad> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync ?? throw new ArgumentNullException(nameof(repositoryAsync));
        }

        public async Task<Response<int>> Handle(UpdateLocalidadCommand request, CancellationToken cancellationToken)
        {
            var localidad = await _repositoryAsync.FirstOrDefaultAsync(new LocalidadByIdSpecification(request.Id), cancellationToken);

            if (localidad == null)
            {
                throw new KeyNotFoundException($"Registro no encontrado con el id {request.Id}");
            }

            localidad.Nombre = request.Nombre;
            localidad.Direccion = request.Direccion;
            localidad.CiudadId = request.CiudadId;

            await _repositoryAsync.UpdateAsync(localidad);

            return new Response<int>(localidad.Id);
        }
    }
}
