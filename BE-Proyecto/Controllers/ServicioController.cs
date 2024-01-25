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
    public class ServicioController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IServicioRepository _servicioRepository;

        public ServicioController(IMapper mapper, IServicioRepository servicioRepository)
        {

            _mapper = mapper;
            _servicioRepository = servicioRepository;

        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var ListServicio = await _servicioRepository.GetListServicio();
                var ListServicioDTO = _mapper.Map<IEnumerable<ServicioDTO>>(ListServicio);
                return Ok(ListServicioDTO);
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
                var servicio = await _servicioRepository.GetServicio(id);
                if (servicio == null)
                {
                    return NotFound();
                }

                var servicioDTO = _mapper.Map<ServicioDTO>(servicio);
                return Ok(servicioDTO);
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
                var servicio = await _servicioRepository.GetServicio(id);
                if (servicio == null)
                {
                    return NotFound();
                }
                await _servicioRepository.DeleteServicio(servicio);
                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(ServicioDTO servicioDto)
        {
            try
            {
                var servicio = _mapper.Map<Servicio>(servicioDto);

                servicio.FechaCreacion = DateTime.Now;
                servicio = await _servicioRepository.AddServicio(servicio);

                var servicioItemDto = _mapper.Map<ServicioDTO>(servicio);

                return CreatedAtAction("Get", new { id = servicioItemDto.Id }, servicioItemDto);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ServicioDTO servicioDto)
        {
            try
            {
                var servicio = _mapper.Map<Servicio>(servicioDto);
                if (id != servicio.Id)
                {
                    return BadRequest();
                }


                var servicioItem = await _servicioRepository.GetServicio(id);
                if (servicioItem == null)
                {
                    return NotFound();
                }

                await _servicioRepository.UpdateServicio(servicio);
                return NoContent();

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }
        }
        
    }
}
