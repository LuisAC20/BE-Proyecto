using AutoMapper;
using BE_Proyecto.Models;
using BE_Proyecto.Models.DTO;
using BE_Proyecto.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BE_Proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IReservaRepository _reservaRepository;

        public ReservaController(IMapper mapper, IReservaRepository reservaRepository)
        {

            _mapper = mapper;
            _reservaRepository = reservaRepository;

        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {

                var ListReserva = await _reservaRepository.GetListReservas();
                var ListReservaDTO = _mapper.Map<IEnumerable<ReservaDTO>>(ListReserva);
                return Ok(ListReservaDTO);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var reserva = await _reservaRepository.GetReserva(id);
                if (reserva == null)
                {
                    return NotFound();
                }

                var reservaDTO = _mapper.Map<ReservaDTO>(reserva);
                return Ok(reservaDTO);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var reserva = await _reservaRepository.GetReserva(id);
                if (reserva == null)
                {
                    return NotFound();
                }
                await _reservaRepository.DeleteReserva(reserva);
                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(ReservaDTO reservaDto)
        {
            try
            {
                var reserva = _mapper.Map<Reserva>(reservaDto);

                reserva.FechaCreacion = DateTime.Now;
                reserva = await _reservaRepository.AddReserva(reserva);

                var reservaItemDto = _mapper.Map<ReservaDTO>(reserva);

                return CreatedAtAction("Get", new { id = reservaItemDto.Id }, reservaItemDto);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ReservaDTO reservaDto)
        {
            try
            {
                var reserva = _mapper.Map<Reserva>(reservaDto);
                if (id != reserva.Id)
                {
                    return BadRequest();
                }


                var reservaItem = await _reservaRepository.GetReserva(id);
                if (reservaItem == null)
                {
                    return NotFound();
                }

                await _reservaRepository.UpdateReserva(reserva);
                return NoContent();

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }
        }


        //consultas dashboard
        /*
        [HttpGet("reservasProximas/{horas}")]
        public async Task<IActionResult> ObtenerCantidadReservasProximaSemana(int horas)
        {
            DateTime ProximasHoras = DateTime.Now.AddHours(horas);

            int cantidadProximasReservas = await _reservaRepository.CantidadReservas(ProximasHoras);

            return Ok(cantidadProximasReservas);
        }*/

        [HttpGet("reservasProximas")]
        public async Task<IActionResult> OtenerCantidadReservasProximaSemana()
        {

            int cantidadProximasReservas = await _reservaRepository.CantidadReservas();

            return Ok(cantidadProximasReservas);
        }

        [HttpGet("totalRegistros")]
        public async Task<IActionResult> ObtenerCantidadTotalReservas()
        {
            int cantidadReservas = await _reservaRepository.CantidadTotalReservas();
            return Ok(cantidadReservas);
        }

    }
}
