using AutoMapper;
using MediatR;
using MilesCarRental.Application.Common.Interfaces;
using MilesCarRental.Application.DTOs;
using MilesCarRental.Application.Specifications.Localidad;
using MilesCarRental.Application.Wrappers;
using MilesCarRental.Domain.Entities;

namespace MilesCarRental.Application.UseCases.Localidades.Queries.GetLocalidadById
{
    public class GetLocalidadByIdQueryHandler : IRequestHandler<GetLocalidadByIdQuery, Response<LocalidadDTO>>
    {
        private readonly IRepositoryAsync<Localidad> _repositoryAsync;
        private readonly IMapper _mapper;

        public GetLocalidadByIdQueryHandler(IRepositoryAsync<Localidad> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync ?? throw new ArgumentNullException(nameof(repositoryAsync));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Response<LocalidadDTO>> Handle(GetLocalidadByIdQuery request, CancellationToken cancellationToken)
        {
            var localidad = await _repositoryAsync.FirstOrDefaultAsync(new LocalidadByIdSpecification(request.Id));

            if (localidad == null)
            {
                throw new KeyNotFoundException($"Registro no encontrado con el id {request.Id}");
            }

            var dto = _mapper.Map<LocalidadDTO>(localidad);
            return new Response<LocalidadDTO>(dto);
        }
    }
}
