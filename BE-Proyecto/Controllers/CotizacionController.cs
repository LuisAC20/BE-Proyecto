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
    public class CotizacionController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICotizacionRepository _cotizacionRepository;

        public CotizacionController(IMapper mapper, ICotizacionRepository cotizacionRepository)
        {
            _mapper = mapper;
            _cotizacionRepository = cotizacionRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get() //listado de cotizaciones
        {
            try
            {
                var listCotizaciones = await _cotizacionRepository.ObtenerListaCotizaciones();

                var listCotizacionesDTO = _mapper.Map<IEnumerable<CotizacionDTO>>(listCotizaciones);

                return Ok(listCotizacionesDTO);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) //cotizacion por id
        {
            try
            {
                var cotizacion = await _cotizacionRepository.ObtenerCotizacion(id);

                if (cotizacion == null)
                {
                    return NotFound();
                }

                var cotizacionDTO = _mapper.Map<CotizacionDTO>(cotizacion);

                return Ok(cotizacionDTO);
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
                var cotizacion = await _cotizacionRepository.ObtenerCotizacion(id);

                if (cotizacion == null)
                {
                    return NotFound();
                }

                await _cotizacionRepository.EliminarCotizacion(cotizacion);

                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            
        }
        
        [HttpPost] //guardar cotizacion
        public async Task<IActionResult> Post (CotizacionDTO cotizacionDTO)
        {
            try
            {
                var cotizacion = _mapper.Map<Cotizacion>(cotizacionDTO);

                cotizacion.FechaCreacion = DateTime.Now;

                cotizacion = await _cotizacionRepository.AgregarCotizacion(cotizacion);

                var CotizacionItemDto = _mapper.Map<CotizacionDTO>(cotizacion);


                return CreatedAtAction("Get", new { id = CotizacionItemDto.Id }, CotizacionItemDto);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, CotizacionDTO cotizacionDTO)
        {
            try
            {
                var cotizacion = _mapper.Map<Cotizacion>(cotizacionDTO);

                if (id != cotizacion.Id)
                {
                    return BadRequest();
                }

                var cotizacionAnt = await _cotizacionRepository.ObtenerCotizacion(id);


                if (cotizacionAnt == null)
                {
                    return NotFound();
                }

                await _cotizacionRepository.ActualizarCotizacion(cotizacion);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        

        
    }
}
