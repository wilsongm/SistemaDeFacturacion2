using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class BillingsController : ControllerBase
    {
        private readonly SystemVentaDbContext _context;

        public BillingsController(SystemVentaDbContext context)
        {
            _context = context;
        }

        // GET: api/Billings
        [HttpGet("[action]")]
        public IEnumerable<BillingDto> GetBilling()
        {
            var list = _context.Billings.Where(x => !x.IsDeleted).ToList();


            return list.Select(p => new BillingDto
            {
              ProductSelled = p.ProductSelled,
              ClientName = p.ClientName,
              Total = p.Total,
              Itbis = p.Itbis,
              ClientType = p.ClientType,
              ProducName = p.ProducName,
              ProductId = p.ProductId,
              Quantity = p.Quantity,
              Fecha = p.Fecha

            });
        }

        // POST: api/Billing
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateBilling([FromBody] BillingDto entityDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var product = await _context.Products.Where(x => x.Id == entityDto.ProductId).FirstOrDefaultAsync();
            var Client = await _context.Clients.Where(x => x.Id == entityDto.ClientId).FirstOrDefaultAsync();



            Billing billing= new Billing
            {
                Fecha = DateTime.Now,
                Quantity = entityDto.Quantity,
                ClientId = entityDto.ClientId,
                ProductId = entityDto.ProductId,
                ProducName = product.Nombre,
                ClientName = Client.Nombre,
                Total = entityDto.Total,
                Itbis = entityDto.Itbis,

            };

            _context.Billings.Add(billing);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
            var productExist = await _context.Stocks.Where(x => x.ProductId == entityDto.ProductId).FirstOrDefaultAsync();

            if (productExist != null)
            {

                var result = productExist.Quantity - entityDto.Quantity;

                productExist.Quantity = result;

                await _context.SaveChangesAsync();

            }
            else
            {
                Stock stock = new Stock
                {
                    Date = DateTime.Now,
                    Quantity = entityDto.Quantity,
                    ProductId = entityDto.ProductId,
                    ProductName = product.Nombre,
                    BillingId = billing.Id
                    
                };

                _context.Stocks.Add(stock);

                try
                {
                    await _context.SaveChangesAsync();

                }
                catch (Exception)
                {

                    throw;
                }


            }


            return Ok(billing);

        }

        // PUT: api/Billings/5
        [HttpPut("[action]")]
        public async Task<IActionResult> EditBilling(BillingDto entityDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (entityDto.Id <= 0)
            {
                return NotFound();
            }

            var result = await _context.Billings.Where(x => x.Id == entityDto.Id).FirstOrDefaultAsync();

            var stock = await _context.Stocks.Where(x => x.BillingId == entityDto.Id).FirstOrDefaultAsync();

            result.Fecha = entityDto.Fecha;
            result.Quantity = entityDto.Quantity;
            result.ClientId = entityDto.ClientId;
            result.ProductId = entityDto.ProductId;
            result.Total = entityDto.Total;
            result.Itbis = entityDto.Itbis;
            stock.Quantity = entityDto.Quantity;
            stock.Date = DateTime.Now;

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