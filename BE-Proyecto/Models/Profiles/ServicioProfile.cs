using AutoMapper;
using BE_Proyecto.Models.DTO;

namespace BE_Proyecto.Models.Profiles
{
    public class ServicioProfile : Profile
    {
        public ServicioProfile()
        {
            CreateMap<Servicio, ServicioDTO>();
            CreateMap<ServicioDTO, Servicio>();
        }
    }
}
