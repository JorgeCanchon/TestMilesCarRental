using AutoMapper;
using MediatR;
using MilesCarRental.Application.Common.Interfaces;
using MilesCarRental.Application.Wrappers;
using MilesCarRental.Domain.Entities;

namespace MilesCarRental.Application.UseCases.Vehiculos.Commands.CreateVehiculoCommand
{
    public class CreateVehiculoCommandHandler : IRequestHandler<CreateVehiculoCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Vehiculo> _repositoryAsync;
        private readonly IMapper _mapper;

        public CreateVehiculoCommandHandler(IRepositoryAsync<Vehiculo> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync ?? throw new ArgumentNullException(nameof(repositoryAsync));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Response<int>> Handle(CreateVehiculoCommand request, CancellationToken cancellationToken)
        {
            var vehiculo = _mapper.Map<Vehiculo>(request);
            var data = await _repositoryAsync.AddAsync(vehiculo);
            return new Response<int>(data.Id);
        }
    }
}
