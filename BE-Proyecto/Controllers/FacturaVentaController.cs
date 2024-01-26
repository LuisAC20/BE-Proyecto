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
    public class FacturaVentaController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IFacturaVentaRepository _facturaVentaRepository;

        public FacturaVentaController(IMapper mapper, IFacturaVentaRepository facturaVentaRepository)
        {

            _mapper = mapper;
            _facturaVentaRepository = facturaVentaRepository;

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {

            try
            {

                var ListFacturaVenta = await _facturaVentaRepository.ObtenerListFacturasVenta();
                var ListFacturaVentaDTO = _mapper.Map<IEnumerable<FacturaVentaDTO>>(ListFacturaVenta);
                return Ok(ListFacturaVentaDTO);

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
                var facturaVenta = await _facturaVentaRepository.ObtenerFacturaVenta(id);
                if (facturaVenta == null)
                {
                    return NotFound();
                }

                var facturaVentaDTO = _mapper.Map<FacturaVentaDTO>(facturaVenta);
                return Ok(facturaVentaDTO);
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
                var facturaVenta = await _facturaVentaRepository.ObtenerFacturaVenta(id);
                if (facturaVenta == null)
                {
                    return NotFound();
                }

                await _facturaVentaRepository.eliminarFacturaVenta(facturaVenta);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(FacturaVentaDTO facturaVentaDTO)
        {
            try
            {
                var facturaVenta = _mapper.Map<FacturaVenta>(facturaVentaDTO);

                facturaVenta.FechaCreacion = DateTime.Now;
                facturaVenta.FechaVenta = DateTime.Now;
                facturaVenta = await _facturaVentaRepository.agregarFacturaVenta(facturaVenta);

                var FacturaVentaItemDTO = _mapper.Map<FacturaVentaDTO>(facturaVenta);

                return CreatedAtAction("Get", new { id = FacturaVentaItemDTO.Id }, FacturaVentaItemDTO);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, FacturaVentaDTO facturaVentaDTO)
        {
            try
            {
                var facturaVenta = _mapper.Map<FacturaVenta>(facturaVentaDTO);
                if (id != facturaVenta.Id)
                {
                    return BadRequest();
                }

                var facturaVentaItem = await _facturaVentaRepository.ObtenerFacturaVenta(id);
                if (facturaVentaItem == null)
                {
                    return NotFound();
                }

                await _facturaVentaRepository.ActualizarFacturaVenta(facturaVenta);

                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }
        }

        //consultas dashboard
        [HttpGet("ventasUltimos7D")]
        public async Task<IActionResult> OtenerCantidadReservasProximaSemana()
        {

            int cantidadVts7D = await _facturaVentaRepository.CantidadVentasUltimos7D();

            return Ok(cantidadVts7D);
        }

        [HttpGet("totalRegistros")]
        public async Task<IActionResult> ObtenerCantidadTotalVentas()
        {
            int cantidadVentas= await _facturaVentaRepository.CantidadTotalVentas();
            return Ok(cantidadVentas);
        }
    }
}
