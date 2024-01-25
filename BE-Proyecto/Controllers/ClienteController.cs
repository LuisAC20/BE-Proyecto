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
    public class ClienteController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IClienteRepository _clienteRepository;

        public ClienteController(IMapper mapper, IClienteRepository clienteRepository)
        {

            _mapper = mapper;
            _clienteRepository = clienteRepository;

        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {

            try
            {

                var ListCliente = await _clienteRepository.GetListCliente();
                var ListClienteDTO = _mapper.Map<IEnumerable<ClienteDTO>>(ListCliente);
                return Ok(ListClienteDTO);

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
                var cliente = await _clienteRepository.GetCliente(id);
                if (cliente == null)
                {
                    return NotFound();
                }

                var clienteDTO = _mapper.Map<ClienteDTO>(cliente);
                return Ok(clienteDTO);
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
                var cliente = await _clienteRepository.GetCliente(id);
                if (cliente == null)
                {
                    return NotFound();
                }
                await _clienteRepository.DeleteCliente(cliente);
                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(ClienteDTO clienteDto)
        {
            try
            {
                var cliente = _mapper.Map<Cliente>(clienteDto);

                cliente.FechaCreacion = DateTime.Now;
                cliente = await _clienteRepository.AddCliente(cliente);

                var clienteItemDto = _mapper.Map<ClienteDTO>(cliente);

                return CreatedAtAction("Get", new { id = clienteItemDto.Id }, clienteItemDto);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ClienteDTO clienteDto)
        {
            try
            {
                var cliente = _mapper.Map<Cliente>(clienteDto);
                if (id != cliente.Id)
                {
                    return BadRequest();
                }


                var clienteItem = await _clienteRepository.GetCliente(id);
                if (clienteItem == null)
                {
                    return NotFound();
                }

                await _clienteRepository.UpdateCliente(cliente);
                return NoContent();

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }
        }
        
    }
}
