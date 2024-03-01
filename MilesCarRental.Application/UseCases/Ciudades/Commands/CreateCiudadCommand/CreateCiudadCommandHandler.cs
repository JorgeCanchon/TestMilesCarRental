using AutoMapper;
using MediatR;
using MilesCarRental.Application.Common.Interfaces;
using MilesCarRental.Application.Wrappers;
using MilesCarRental.Domain.Entities;

namespace MilesCarRental.Application.UseCases.Ciudades.Commands.CreateCiudadCommand
{
    public class CreateCiudadCommandHandler : IRequestHandler<CreateCiudadCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Ciudad> _repositoryAsync;
        private readonly IMapper _mapper;

        public CreateCiudadCommandHandler(IRepositoryAsync<Ciudad> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync ?? throw new ArgumentNullException(nameof(repositoryAsync));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Response<int>> Handle(CreateCiudadCommand request, CancellationToken cancellationToken)
        {
            var ciudad = _mapper.Map<Ciudad>(request);
            var data = await _repositoryAsync.AddAsync(ciudad);
            return new Response<int>(data.Id);
        }
    }
}
