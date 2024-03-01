using AutoMapper;
using MediatR;
using MilesCarRental.Application.Common.Interfaces;
using MilesCarRental.Application.DTOs;
using MilesCarRental.Application.Specifications.Vehiculo;
using MilesCarRental.Application.Wrappers;
using MilesCarRental.Domain.Entities;

namespace MilesCarRental.Application.UseCases.Vehiculos.Queries.GetVehiculosAvailables
{
    public class GetVehiculosAvailablesQueryHandler : IRequestHandler<GetVehiculosAvailablesQuery, Response<List<VehiculoDTO>>>
    {
        private readonly IRepositoryAsync<Vehiculo> _repositoryAsync;
        private readonly IMapper _mapper;

        public GetVehiculosAvailablesQueryHandler(IRepositoryAsync<Vehiculo> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync ?? throw new ArgumentNullException(nameof(repositoryAsync));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Response<List<VehiculoDTO>>> Handle(GetVehiculosAvailablesQuery request, CancellationToken cancellationToken)
        {
            var vehiculos = await _repositoryAsync.ListAsync(new VehiculoAvailablesByLocalidadSpecification(
                    request.LocalidadRecogidaId,
                    request.LocalidadDevolucionId
                ));

            if (!vehiculos.Any())
            {
                throw new KeyNotFoundException($"NO se encontraton vehiculos disponibles para la localidad de recogida {request.LocalidadRecogidaId} y localidad de devolucion {request.LocalidadDevolucionId}");
            }

            var dto = _mapper.Map<List<VehiculoDTO>>(vehiculos);
            return new Response<List<VehiculoDTO>>(dto);
        }
    }
}
