using AutoMapper;
using BE_Proyecto.Models.DTO;

namespace BE_Proyecto.Models.Profiles
{
    public class ClienteProfile : Profile
    {
        public ClienteProfile()
        {
            CreateMap<Cliente, ClienteDTO>();
            CreateMap<ClienteDTO, Cliente>();
        }
    }
}
