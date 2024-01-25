using AutoMapper;
using BE_Proyecto.Models.DTO;

namespace BE_Proyecto.Models.Profiles
{
    public class CotizacionProfile : Profile
    {
        public CotizacionProfile() 
        {
            CreateMap<Cotizacion, CotizacionDTO>();
            CreateMap<CotizacionDTO, Cotizacion>();
        }
    }
}
