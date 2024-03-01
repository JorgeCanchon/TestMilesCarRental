using MediatR;
using MilesCarRental.Application.Common.Interfaces;
using MilesCarRental.Application.Specifications.Localidad;
using MilesCarRental.Application.Wrappers;
using MilesCarRental.Domain.Entities;

namespace MilesCarRental.Application.UseCases.Localidades.Commands.DeleteLocalidadCommand
{
    public class DeleteLocalidadCommandHandler : IRequestHandler<DeleteLocalidadCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Localidad> _repositoryAsync;

        public DeleteLocalidadCommandHandler(IRepositoryAsync<Localidad> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync ?? throw new ArgumentNullException(nameof(repositoryAsync));
        }

        public async Task<Response<int>> Handle(DeleteLocalidadCommand request, CancellationToken cancellationToken)
        {
            var localidad = await _repositoryAsync.FirstOrDefaultAsync(new LocalidadByIdSpecification(request.Id));

            if (localidad == null)
            {
                throw new KeyNotFoundException($"Registro no encontrado con el id {request.Id}");
            }

            await _repositoryAsync.DeleteAsync(localidad);

            return new Response<int>(localidad.Id);
        }
    }
}
