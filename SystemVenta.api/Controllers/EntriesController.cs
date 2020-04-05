using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SystemVenta.Bi.Dto;
using SystemVenta.Model.Entities;
using SystemVenta.Model.SystemVentaDb;

namespace SystemVenta.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntriesController : ControllerBase
    {
        private readonly SystemVentaDbContext _context;

        public EntriesController(SystemVentaDbContext context)
        {
            _context = context;
        }

        // GET: api/Entries
        [HttpGet("[action]")]
        public IEnumerable<EntryDto> GetEntry()
        {
            var list = _context.Entries.Where(x => !x.IsDeleted).ToList();


            return list.Select(p => new EntryDto
            {
                Id = p.Id,
                Fecha = p.Fecha,
                Quantity = p.Quantity,
                ProductName = p.ProductName,
                ProviderId = p.ProviderId,
                ProductId = p.ProductId,
                ProviderName = p.ProviderName
            });
        }

        // POST: api/Entries
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateEntry([FromBody] EntryDto entityDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var product = await _context.Products.Where(x => x.Id == entityDto.ProductId).FirstOrDefaultAsync();
            var provider = await _context.Providers.Where(x => x.Id == entityDto.ProviderId).FirstOrDefaultAsync();


            Entry entry = new Entry
            {
                Fecha = DateTime.Now,
                Quantity = entityDto.Quantity,
                ProviderId = entityDto.ProviderId,
                ProductId = entityDto.ProductId,
                ProductName = product.Nombre,
                ProviderName = provider.Nombre

            };

            _context.Entries.Add(entry);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
            return Ok(entry);

        }


        // PUT: api/Entries/5
        [HttpPut("[action]")]
        public async Task<IActionResult> EditEntry(EntryDto entityDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (entityDto.Id <= 0)
            {
                return NotFound();
            }

            var result = await _context.Entries.Where(x => x.Id == entityDto.Id).FirstOrDefaultAsync();

            result.Fecha = entityDto.Fecha;
            result.Quantity = entityDto.Quantity;
            result.ProviderId = entityDto.ProviderId;
            result.ProductId = entityDto.ProductId;
            

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
        public async Task<IActionResult> DeleteEntry(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var entry = await _context.Entries.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (entry is null)
                return NotFound();


            entry.IsDeleted = true;

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
