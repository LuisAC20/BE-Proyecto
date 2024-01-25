using AutoMapper;
using BE_Proyecto.Models.DTO;

namespace BE_Proyecto.Models.Profiles
{
    public class TicketProfile : Profile
    {
        public TicketProfile()
        {
            CreateMap<Ticket, TicketDTO>();
            CreateMap<TicketDTO, Ticket>();

        }
    }
}
