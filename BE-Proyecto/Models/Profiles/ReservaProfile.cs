using AutoMapper;
using BE_Proyecto.Models.DTO;

namespace BE_Proyecto.Models.Profiles
{
    public class ReservaProfile : Profile
    {
        public ReservaProfile()
        {
            CreateMap<Reserva, ReservaDTO>();
            CreateMap<ReservaDTO, Reserva>();
        }
    }
}
