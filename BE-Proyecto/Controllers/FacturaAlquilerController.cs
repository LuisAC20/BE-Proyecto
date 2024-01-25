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
    public class FacturaAlquilerController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IFacturaAlquilerRepository _facturaAlquilerRepository;

        public FacturaAlquilerController(IMapper mapper, IFacturaAlquilerRepository facturaAlquilerRepository)
        {

            _mapper = mapper;
            _facturaAlquilerRepository = facturaAlquilerRepository;

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {

            try
            {

                var ListFacturaAlquiler = await _facturaAlquilerRepository.ObtenerListFacturasAlquiler();
                var ListFacturaAlquilerDTO = _mapper.Map<IEnumerable<FacturaAlquilerDTO>>(ListFacturaAlquiler);
                return Ok(ListFacturaAlquilerDTO);

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
                var facturaAlquiler = await _facturaAlquilerRepository.ObtenerFacturaAlquiler(id);
                if (facturaAlquiler == null)
                {
                    return NotFound();
                }

                var facturaAlquilerDTO = _mapper.Map<FacturaAlquilerDTO>(facturaAlquiler);
                return Ok(facturaAlquilerDTO);
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
                var facturaAlquiler = await _facturaAlquilerRepository.ObtenerFacturaAlquiler(id);
                if (facturaAlquiler == null)
                {
                    return NotFound();
                }

                await _facturaAlquilerRepository.eliminarFacturaAlquiler(facturaAlquiler);
                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(FacturaAlquilerDTO facturaAlquilerDTO)
        {
            try
            {
                var facturaAlquiler = _mapper.Map<FacturaAlquiler>(facturaAlquilerDTO);

                facturaAlquiler.FechaCreacion = DateTime.Now;
                facturaAlquiler = await _facturaAlquilerRepository.agregarFacturaAlquiler(facturaAlquiler);

                var facturaAlquilerItemDTO = _mapper.Map<FacturaAlquilerDTO>(facturaAlquiler);

                return CreatedAtAction("Get", new { id = facturaAlquilerItemDTO.Id }, facturaAlquilerItemDTO);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, FacturaAlquilerDTO facturaAlquilerDTO)
        {
            try
            {
                var facturaAlquiler = _mapper.Map<FacturaAlquiler>(facturaAlquilerDTO);
                if (id != facturaAlquiler.Id)
                {
                    return BadRequest();
                }

                var facturaAlquilerItem = await _facturaAlquilerRepository.ObtenerFacturaAlquiler(id);
                if (facturaAlquilerItem == null)
                {
                    return NotFound();
                }

                await _facturaAlquilerRepository.ActualizarFacturaAlquiler(facturaAlquiler);

                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }
        }
    }
}
