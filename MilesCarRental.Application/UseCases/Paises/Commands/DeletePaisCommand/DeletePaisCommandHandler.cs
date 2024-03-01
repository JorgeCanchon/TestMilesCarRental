using MediatR;
using MilesCarRental.Application.Common.Interfaces;
using MilesCarRental.Application.Specifications.Pais;
using MilesCarRental.Application.Wrappers;
using MilesCarRental.Domain.Entities;

namespace MilesCarRental.Application.UseCases.Paises.Commands.DeletePaisCommand
{
    public class DeletePaisCommandHandler : IRequestHandler<DeletePaisCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Pais> _repositoryAsync;

        public async Task<Response<int>> Handle(DeletePaisCommand request, CancellationToken cancellationToken)
        {
            var pais = await _repositoryAsync.FirstOrDefaultAsync(new PaisByIdSpecification(request.Id));

            if (pais == null)
            {
                throw new KeyNotFoundException($"Registro no encontrado con el id {request.Id}");
            }

            await _repositoryAsync.DeleteAsync(pais);

            return new Response<int>(pais.Id);
        }
    }
}
