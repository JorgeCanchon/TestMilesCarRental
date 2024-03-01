using AutoMapper;
using MediatR;
using MilesCarRental.Application.Common.Interfaces;
using MilesCarRental.Application.Wrappers;
using MilesCarRental.Domain.Entities;

namespace MilesCarRental.Application.UseCases.Localidades.Commands.CreateLocalidadCommand
{
    public class CreateLocalidadCommandHandler : IRequestHandler<CreateLocalidadCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Localidad> _repositoryAsync;
        private readonly IMapper _mapper;

        public CreateLocalidadCommandHandler(IRepositoryAsync<Localidad> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync ?? throw new ArgumentNullException(nameof(repositoryAsync));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Response<int>> Handle(CreateLocalidadCommand request, CancellationToken cancellationToken)
        {
            var localidad = _mapper.Map<Localidad>(request);
            var data = await _repositoryAsync.AddAsync(localidad);
            return new Response<int>(data.Id);
        }
    }
}
