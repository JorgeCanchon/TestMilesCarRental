using MediatR;
using MilesCarRental.Application.Common.Interfaces;
using MilesCarRental.Application.Specifications.Ciudad;
using MilesCarRental.Application.Wrappers;
using MilesCarRental.Domain.Entities;

namespace MilesCarRental.Application.UseCases.Ciudades.Commands.DeleteCiudadCommand
{
    public class DeleteCiudadCommandHandler : IRequestHandler<DeleteCiudadCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Ciudad> _repositoryAsync;

        public DeleteCiudadCommandHandler(IRepositoryAsync<Ciudad> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync ?? throw new ArgumentNullException(nameof(repositoryAsync));
        }

        public async Task<Response<int>> Handle(DeleteCiudadCommand request, CancellationToken cancellationToken)
        {
            var ciudad = await _repositoryAsync.FirstOrDefaultAsync(new CiudadByIdSpecification(request.Id));

            if (ciudad == null)
            {
                throw new KeyNotFoundException($"Registro no encontrado con el id {request.Id}");
            }

            await _repositoryAsync.DeleteAsync(ciudad);

            return new Response<int>(ciudad.Id);
        }
    }
}
