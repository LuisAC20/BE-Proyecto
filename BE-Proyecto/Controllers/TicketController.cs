using AutoMapper;
using BE_Proyecto.Models;
using BE_Proyecto.Models.DTO;
using BE_Proyecto.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BE_Proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITicketRepository _ticketRepository;

        public TicketController(IMapper mapper, ITicketRepository ticketRepository)
        {
            _mapper = mapper;
            _ticketRepository = ticketRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get() //listado de tickets
        {
            try
            {
                var listTickets = await _ticketRepository.ObtenerListadoTickets();

                var listTicketsDTO = _mapper.Map<IEnumerable<TicketDTO>>(listTickets);

                return Ok(listTicketsDTO);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) //tickets por id
        {
            try
            {
                var ticket = await _ticketRepository.ObtenerTicket(id);

                if (ticket == null)
                {
                    return NotFound();
                }

                var ticketDTO = _mapper.Map<TicketDTO>(ticket);

                return Ok(ticketDTO);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) //delete id
        {
            try
            {
                var ticket = await _ticketRepository.ObtenerTicket(id);

                if (ticket == null)
                {
                    return NotFound();
                }

                await _ticketRepository.EliminarTicket(ticket);

                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
        
        [HttpPost] //guardar ticket
        public async Task<IActionResult> Post(TicketDTO ticketDTO)
        {
            try
            {
                var ticket = _mapper.Map<Ticket>(ticketDTO);

                ticket.FechaCreacion = DateTime.Now;

                ticket = await _ticketRepository.AgregarTicket(ticket);

                var ticketItemDto = _mapper.Map<TicketDTO>(ticket);

                return CreatedAtAction("Get", new { id = ticketItemDto.Id }, ticketItemDto);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, TicketDTO ticketDTO)
        {
            try
            {
                var ticket = _mapper.Map<Ticket>(ticketDTO);

                if (id != ticket.Id)
                {
                    return BadRequest();
                }

                var ticketAnt = await _ticketRepository.ObtenerTicket(id);


                if (ticketAnt == null)
                {
                    return NotFound();
                }

                await _ticketRepository.ActualizarTicket(ticket);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
    }
}
