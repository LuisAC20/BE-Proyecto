using AutoMapper;
using BE_Proyecto.Models.DTO;

namespace BE_Proyecto.Models.Profiles
{
    public class FacturaAlquilerProfile : Profile
    {
        public FacturaAlquilerProfile()
        {
            CreateMap<FacturaAlquiler, FacturaAlquilerDTO>();
            CreateMap<FacturaAlquilerDTO, FacturaAlquiler>();
        }
    }
}
