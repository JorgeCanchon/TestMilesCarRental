using AutoMapper;
using MediatR;
using MilesCarRental.Application.Common.Interfaces;
using MilesCarRental.Application.DTOs;
using MilesCarRental.Application.Wrappers;
using MilesCarRental.Domain.Entities;

namespace MilesCarRental.Application.UseCases.Vehiculos.Queries.GetAllVehiculos
{
    public class GetAllVehiculosQueryHandler : IRequestHandler<GetAllVehiculosQuery, Response<List<VehiculoDTO>>>
    {
        private readonly IRepositoryAsync<Vehiculo> _repositoryAsync;
        private readonly IMapper _mapper;

        public GetAllVehiculosQueryHandler(IRepositoryAsync<Vehiculo> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync ?? throw new ArgumentNullException(nameof(repositoryAsync));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Response<List<VehiculoDTO>>> Handle(GetAllVehiculosQuery request, CancellationToken cancellationToken)
        {
            var vehiculos = await _repositoryAsync.ListAsync();
            if (!vehiculos.Any())
            {
                throw new KeyNotFoundException($"No existen registros para mostrar");
            }

            var dto = _mapper.Map<List<VehiculoDTO>>(vehiculos);
            return new Response<List<VehiculoDTO>>(dto);
        }
    }
}
