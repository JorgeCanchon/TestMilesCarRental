using AutoMapper;
using MediatR;
using MilesCarRental.Application.Common.Interfaces;
using MilesCarRental.Application.DTOs;
using MilesCarRental.Application.Specifications.Pais;
using MilesCarRental.Application.Wrappers;
using MilesCarRental.Domain.Entities;

namespace MilesCarRental.Application.UseCases.Paises.Queries.GetPaisesById
{
    public class GetPaisesByIdHandler : IRequestHandler<GetPaisesByIdQuery, Response<PaisDTO>>
    {
        private readonly IRepositoryAsync<Pais> _repositoryAsync;
        private readonly IMapper _mapper;

        public GetPaisesByIdHandler(IRepositoryAsync<Pais> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync ?? throw new ArgumentNullException(nameof(repositoryAsync));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Response<PaisDTO>> Handle(GetPaisesByIdQuery request, CancellationToken cancellationToken)
        {
            var pais = await _repositoryAsync.FirstOrDefaultAsync(new PaisByIdSpecification(request.Id));

            if (pais == null)
            {
                throw new KeyNotFoundException($"Registro no encontrado con el id {request.Id}");
            }

            var dto = _mapper.Map<PaisDTO>(pais);
            return new Response<PaisDTO>(dto);
        }
    }
}
