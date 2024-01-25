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
    public class VehiculoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IVehiculoRepository _vehiculoRepository;

        public VehiculoController(IMapper mapper, IVehiculoRepository vehiculoRepository)
        {
            _mapper = mapper;
            _vehiculoRepository = vehiculoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get() //listado de vehiculos
        {
            try
            {
                var listVehiculos = await _vehiculoRepository.ObtenerListVehiculos();

                var listVehiculosDTO = _mapper.Map<IEnumerable<VehiculoDTO>>(listVehiculos);

                return Ok(listVehiculosDTO);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) //vehiculo por id
        {
            try
            {
                var vehiculo = await _vehiculoRepository.ObtenerVehiculo(id);

                if (vehiculo == null)
                {
                    return NotFound();
                }

                var vehiculoDTO = _mapper.Map<VehiculoDTO>(vehiculo);

                return Ok(vehiculoDTO);
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
                var vehiculo = await _vehiculoRepository.ObtenerVehiculo(id);

                if (vehiculo == null)
                {
                    return NotFound();
                }

                await _vehiculoRepository.eliminarVehiculo(vehiculo);

                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
        
        [HttpPost] //guardar vehiculo
        public async Task<IActionResult> Post(VehiculoDTO vehiculoDTO)
        {
            try
            {
                var vehiculo = _mapper.Map<Vehiculo>(vehiculoDTO);

                vehiculo.FechaCreacion = DateTime.Now;

                vehiculo = await _vehiculoRepository.AgregarVehiculo(vehiculo);

                var vehiculoItemDto = _mapper.Map<VehiculoDTO>(vehiculo);

                return CreatedAtAction("Get", new { id = vehiculoItemDto.Id }, vehiculoItemDto); //rev segu consoleApp
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, VehiculoDTO vehiculoDTO)
        {
            try
            {
                var vehiculo = _mapper.Map<Vehiculo>(vehiculoDTO);

                if (id != vehiculo.Id)
                {
                    return BadRequest();
                }

                var vehiculoAnt = await _vehiculoRepository.ObtenerVehiculo(id);


                if (vehiculoAnt == null)
                {
                    return NotFound();
                }

                await _vehiculoRepository.ActualizarVehiculo(vehiculo);

                return NoContent(); //rev, sería ok()?
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        
    }
}
