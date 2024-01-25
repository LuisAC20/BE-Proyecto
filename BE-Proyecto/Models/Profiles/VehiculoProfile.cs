using AutoMapper;
using BE_Proyecto.Models.DTO;

namespace BE_Proyecto.Models.Profiles
{
    public class VehiculoProfile : Profile
    {
        public VehiculoProfile() 
        {
            CreateMap<Vehiculo, VehiculoDTO>();
            CreateMap<VehiculoDTO, Vehiculo>();
        }
    }
}
