using BE_Proyecto.Models;
using BE_Proyecto.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BE_Proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaAutolavadoController : ControllerBase
    {
        private readonly IFacturaLavadoRepository _facturaLavadoRepository;
        
        public FacturaAutolavadoController(IFacturaLavadoRepository facturaLavadoRepository)
        {
            _facturaLavadoRepository = facturaLavadoRepository;
        }
        
        [HttpGet]
        public async Task<IActionResult> Get() //listado de facturas lavado
        {
            try
            {
                var listFacturasLavd = await _facturaLavadoRepository.ObtenerListFacturasLavado();
                return Ok(listFacturasLavd);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) //factura lavado por id
        {
            try
            {
                var facturaLavado = await _facturaLavadoRepository.ObtenerFacturaLavado(id);

                if (facturaLavado == null)
                {
                    return NotFound();
                }
                return Ok(facturaLavado);
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
                var facturaLavado = await _facturaLavadoRepository.ObtenerFacturaLavado(id);

                if (facturaLavado == null)
                {
                    return NotFound();
                }

                await _facturaLavadoRepository.eliminarFacturaLavado(facturaLavado);

                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        
        [HttpPost] //guardar factura lavado
        public async Task<IActionResult> Post(FacturaAutolavado facturaLavado)
        {
            try
            {
                facturaLavado.FechaEmision = DateTime.Now;

                facturaLavado = await _facturaLavadoRepository.agregarFacturaLavado(facturaLavado);

                return CreatedAtAction("Get", new { id = facturaLavado.Id }, facturaLavado); //rev segu consoleApp
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, FacturaAutolavado facturaLavado) //update
        {
            try
            {
                if (id != facturaLavado.Id)
                {
                    return BadRequest();
                }

                var facturaLvdAnt = await _facturaLavadoRepository.ObtenerFacturaLavado(id);


                if (facturaLvdAnt == null)
                {
                    return NotFound();
                }

                await _facturaLavadoRepository.ActualizarFacturaLavado(facturaLavado);

                return NoContent(); //rev, sería ok()?
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
    }
}
