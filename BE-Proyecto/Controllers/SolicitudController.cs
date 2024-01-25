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
    public class SolicitudController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISolicitudRepository _solicitudRepository;

        public SolicitudController(IMapper mapper, ISolicitudRepository solicitudRepository)
        {

            _mapper = mapper;
            _solicitudRepository = solicitudRepository;

        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var ListSolicitud = await _solicitudRepository.GetListSolicitudes();
                var ListSolicitudDTO = _mapper.Map<IEnumerable<SolicitudDTO>>(ListSolicitud);
                return Ok(ListSolicitudDTO);

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
                var solicitud = await _solicitudRepository.GetSolicitud(id);
                if (solicitud == null)
                {
                    return NotFound();
                }

                var solicitudDTO = _mapper.Map<SolicitudDTO>(solicitud);
                return Ok(solicitudDTO);
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
                var solicitud = await _solicitudRepository.GetSolicitud(id);
                if (solicitud == null)
                {
                    return NotFound();
                }
                await _solicitudRepository.DeleteSolicitud(solicitud);
                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(SolicitudDTO solicitudDto)
        {
            try
            {
                var solicitud = _mapper.Map<Solicitud>(solicitudDto);

                solicitud.FechaCreacion = DateTime.Now;
                solicitud = await _solicitudRepository.AddSolicitud(solicitud);

                var solicitudItemDto = _mapper.Map<SolicitudDTO>(solicitud);

                return CreatedAtAction("Get", new { id = solicitudItemDto.Id }, solicitudItemDto);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, SolicitudDTO solicitudDto)
        {
            try
            {
                var solicitud = _mapper.Map<Solicitud>(solicitudDto);
                if (id != solicitud.Id)
                {
                    return BadRequest();
                }


                var solicitudItem = await _solicitudRepository.GetSolicitud(id);
                if (solicitudItem == null)
                {
                    return NotFound();
                }

                await _solicitudRepository.UpdateSolicitud(solicitud);
                return NoContent();

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }
        }
        
    }
}
