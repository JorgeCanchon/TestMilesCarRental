using AutoMapper;
using MilesCarRental.Application.DTOs;
using MilesCarRental.Application.UseCases.Paises.Commands.CreatePaisCommand;
using MilesCarRental.Domain.Entities;

namespace MilesCarRental.Application.Common.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            #region DTOs
            CreateMap<Pais, PaisDTO>();
            #endregion

            #region Commands
            CreateMap<CreatePaisCommand, Pais>().ReverseMap();
            #endregion
        }
    }
}
