using AutoMapper;
using MediatR;
using MilesCarRental.Application.Common.Interfaces;
using MilesCarRental.Application.DTOs;
using MilesCarRental.Application.Wrappers;
using MilesCarRental.Domain.Entities;

namespace MilesCarRental.Application.UseCases.Paises.Queries.GetAllPaises
{
    public class GetAllPaisesQueryHandler : IRequestHandler<GetAllPaisesQuery, Response<List<PaisDTO>>>
    {
        private readonly IRepositoryAsync<Pais> _repositoryAsync;
        private readonly IMapper _mapper;

        public GetAllPaisesQueryHandler(IRepositoryAsync<Pais> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync ?? throw new ArgumentNullException(nameof(repositoryAsync));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Response<List<PaisDTO>>> Handle(GetAllPaisesQuery request, CancellationToken cancellationToken)
        {
            var paises = await _repositoryAsync.ListAsync();
            if (!paises.Any())
            {
                throw new KeyNotFoundException($"No existen registros para mostrar");
            }

            var dto = _mapper.Map<List<PaisDTO>>(paises);
            return new Response<List<PaisDTO>>(dto);
        }
    }
}
