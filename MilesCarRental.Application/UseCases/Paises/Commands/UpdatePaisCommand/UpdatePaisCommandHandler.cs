using MediatR;
using MilesCarRental.Application.Common.Interfaces;
using MilesCarRental.Application.Specifications.Pais;
using MilesCarRental.Application.Wrappers;
using MilesCarRental.Domain.Entities;

namespace MilesCarRental.Application.UseCases.Paises.Commands.UpdatePaisCommand
{
    public class UpdatePaisCommandHandler : IRequestHandler<UpdatePaisCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Pais> _repositoryAsync;

        public UpdatePaisCommandHandler(IRepositoryAsync<Pais> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync ?? throw new ArgumentNullException(nameof(repositoryAsync));
        }

        public async Task<Response<int>> Handle(UpdatePaisCommand request, CancellationToken cancellationToken)
        {

            var pais = await _repositoryAsync.FirstOrDefaultAsync(new PaisByIdSpecification(request.Id), cancellationToken);
           
            if (pais == null)
            {
                throw new KeyNotFoundException($"Registro no encontrado con el id {request.Id}");
            }

            pais.Nombre = request.Nombre;

            await _repositoryAsync.UpdateAsync(pais);

            return new Response<int>(pais.Id);
        }
    }
}
