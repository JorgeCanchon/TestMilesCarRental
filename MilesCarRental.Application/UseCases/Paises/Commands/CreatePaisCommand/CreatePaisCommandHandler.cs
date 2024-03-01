using AutoMapper;
using MediatR;
using MilesCarRental.Application.Common.Interfaces;
using MilesCarRental.Application.Wrappers;
using MilesCarRental.Domain.Entities;

namespace MilesCarRental.Application.UseCases.Paises.Commands.CreatePaisCommand
{
    public class CreatePaisCommandHandler : IRequestHandler<CreatePaisCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Pais> _repositoryAsync;
        private readonly IMapper _mapper;

        public CreatePaisCommandHandler(IRepositoryAsync<Pais> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync ?? throw new ArgumentNullException(nameof(repositoryAsync));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Response<int>> Handle(CreatePaisCommand request, CancellationToken cancellationToken)
        {
            var pais = _mapper.Map<Pais>(request);
            var data = await _repositoryAsync.AddAsync(pais);
            return new Response<int>(data.Id);
        }
    }
}
