using AutoMapper;
using MilesCarRental.Application.DTOs;
using MilesCarRental.Application.UseCases.Ciudades.Commands.CreateCiudadCommand;
using MilesCarRental.Application.UseCases.Localidades.Commands.CreateLocalidadCommand;
using MilesCarRental.Application.UseCases.Paises.Commands.CreatePaisCommand;
using MilesCarRental.Application.UseCases.Vehiculos.Commands.CreateVehiculoCommand;
using MilesCarRental.Domain.Entities;

namespace MilesCarRental.Application.Common.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            #region DTOs
            CreateMap<Pais, PaisDTO>();
            CreateMap<Ciudad, CiudadDTO>();
            CreateMap<Localidad, LocalidadDTO>();
            CreateMap<Vehiculo, VehiculoDTO>();
            #endregion

            #region Commands
            CreateMap<CreatePaisCommand, Pais>().ReverseMap();
            CreateMap<CreateCiudadCommand, Ciudad>().ReverseMap();
            CreateMap<CreateLocalidadCommand, Localidad>().ReverseMap();
            CreateMap<CreateVehiculoCommand, Vehiculo>().ReverseMap();
            #endregion
        }
    }
}
