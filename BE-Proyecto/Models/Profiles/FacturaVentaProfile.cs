using AutoMapper;
using BE_Proyecto.Models.DTO;

namespace BE_Proyecto.Models.Profiles
{
    public class FacturaVentaProfile : Profile
    {
        public FacturaVentaProfile()
        {
            CreateMap<FacturaVenta, FacturaVentaDTO>();
            CreateMap<FacturaVentaDTO, FacturaVenta>();
        }
    }
}
