using AutoMapper;
using BE_Proyecto.Models.DTO;

namespace BE_Proyecto.Models.Profiles
{
    public class SolicitudProfile : Profile
    {
        public SolicitudProfile()
        {
            CreateMap<Solicitud, SolicitudDTO>();
            CreateMap<SolicitudDTO, Solicitud>();
        }
    }
}
