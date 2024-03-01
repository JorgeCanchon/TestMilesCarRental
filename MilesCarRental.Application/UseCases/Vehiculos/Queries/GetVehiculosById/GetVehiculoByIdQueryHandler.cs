using AutoMapper;
using MediatR;
using MilesCarRental.Application.Common.Interfaces;
using MilesCarRental.Application.DTOs;
using MilesCarRental.Application.Specifications.Vehiculo;
using MilesCarRental.Application.Wrappers;
using MilesCarRental.Domain.Entities;

namespace MilesCarRental.Application.UseCases.Vehiculos.Queries.GetVehiculosById
{
    public class GetVehiculoByIdQueryHandler : IRequestHandler<GetVehiculoByIdQuery, Response<VehiculoDTO>>
    {
        private readonly IRepositoryAsync<Vehiculo> _repositoryAsync;
        private readonly IMapper _mapper;

        public GetVehiculoByIdQueryHandler(IRepositoryAsync<Vehiculo> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync ?? throw new ArgumentNullException(nameof(repositoryAsync));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Response<VehiculoDTO>> Handle(GetVehiculoByIdQuery request, CancellationToken cancellationToken)
        {
            var vehiculo = await _repositoryAsync.FirstOrDefaultAsync(new VehiculoByIdSpecification(request.Id));

            if (vehiculo == null)
            {
                throw new KeyNotFoundException($"Registro no encontrado con el id {request.Id}");
            }

            var dto = _mapper.Map<VehiculoDTO>(vehiculo);
            return new Response<VehiculoDTO>(dto);
        }
    }
}
