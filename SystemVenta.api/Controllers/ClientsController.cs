using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemVenta.api.BaseRepository.IGenericRepository;
using SystemVenta.Bi.Dto;
using SystemVenta.Model.Entities;
using SystemVenta.Model.SystemVentaDb;

namespace SystemVenta.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientRepository _prociderRepository;
        private readonly IMapper _mapper;
        private readonly SystemVentaDbContext _context;

        public ClientsController(IClientRepository ClientRepository, IMapper mapper, SystemVentaDbContext context)
        {
            _prociderRepository = ClientRepository;
            _mapper = mapper;
            this._context = context;
        }
        // GET: api/Clients
        [HttpGet("[action]")]
        public IEnumerable<ClientDto> GetClient()
        {
            var list = _context.Clients.Where(x => !x.IsDeleted).ToList();


            return list.Select(p => new ClientDto
            {
                Id = p.Id,
                Cedula = p.Cedula,
                Nombre = p.Nombre,
                Telefono = p.Telefono,
                Email = p.Email,
                Category =p.Category

            });
        }
        [HttpGet("[action]")]
        public IEnumerable<ClientDto> GetClientPrimiun()
        {
            var list = _context.Clients.Where(x => !x.IsDeleted && x.Category == "Primiun").ToList();


            return list.Select(p => new ClientDto
            {
                Id = p.Id,
                Nombre = p.Nombre,

            });
        }

        [HttpGet("[action]")]
        public IEnumerable<ClientDto> GetClientRegular()
        {
            var list = _context.Clients.Where(x => !x.IsDeleted && x.Category == "Regular").ToList();


            return list.Select(p => new ClientDto
            {
                Id = p.Id,
                Nombre = p.Nombre,
               

            });
        }

        // POST: api/Clients
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateClient([FromBody] ClientDto entityDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
     

            Client client = new Client
            {
                Cedula = entityDto.Cedula,
                Nombre = entityDto.Nombre,
                Telefono = entityDto.Telefono,
                Email = entityDto.Email,
                Category = entityDto.Category           
                
            };

            _context.Clients.Add(client);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
            return Ok(client);

        }


        // PUT: api/Clients/5
        [HttpPut("[action]")]
        public async Task<IActionResult> EditClient(ClientDto entityDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (entityDto.Id <= 0)
            {
                return NotFound();
            }

            var result = await _context.Clients.Where(x => x.Id == entityDto.Id).FirstOrDefaultAsync();

            result.Cedula = entityDto.Cedula;
            result.Nombre = entityDto.Nombre;
            result.Telefono = entityDto.Telefono;
            result.Email = entityDto.Email;
            result.Category = entityDto.Category;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
            return Ok();

        }

        // DELETE: api/ApiWithActions/5
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var client = await _context.Clients.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (client is null)
                return NotFound();


            client.IsDeleted = true;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
            return Ok();
        }
    }
}
