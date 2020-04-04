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
    public class providersController : ControllerBase
    {
        private readonly IProviderRepository _prociderRepository;
        private readonly IMapper _mapper;
        private readonly SystemVentaDbContext _context;

        public providersController(IProviderRepository ProviderRepository, IMapper mapper, SystemVentaDbContext context)
        {
            _prociderRepository = ProviderRepository;
            _mapper = mapper;
            this._context = context;
        }
        // GET: api/providers
        [HttpGet("[action]")]
        public IEnumerable<ProviderDto> GetProvider()
        {
            var list = _context.Providers.Where(x => !x.IsDeleted).ToList();


            return list.Select(p => new ProviderDto
            {
                Id = p.Id,
                Cedula = p.Cedula,
                Nombre = p.Nombre,
                Telefono = p.Telefono,
                Email = p.Email
            });
        }



        // POST: api/providers
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateProvider([FromBody] ProviderDto entityDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            Provider provider = new Provider
            {
                Cedula = entityDto.Cedula,
                Nombre = entityDto.Nombre,
                Telefono = entityDto.Telefono,
                Email = entityDto.Email
            };
            _context.Providers.Add(provider);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
            return Ok(provider);

        }

        // PUT: api/providers/5
        [HttpPut("[action]")]
        public async Task<IActionResult> EditProvider(ProviderDto entityDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (entityDto.Id <= 0)
            {
                return NotFound();
            }

            var result = await _context.Providers.Where(x => x.Id == entityDto.Id).FirstOrDefaultAsync();

            result.Cedula = entityDto.Cedula;
            result.Nombre = entityDto.Nombre;
            result.Telefono = entityDto.Telefono;
            result.Email = entityDto.Email;
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
        public async Task<IActionResult> DeleteProvider(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var provider = await _context.Providers.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (provider is null)
                return NotFound();


            provider.IsDeleted = true;

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
