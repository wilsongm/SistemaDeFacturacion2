using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SystemVenta.Bi.Dto;
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


        [HttpGet("[action]")]
        public IEnumerable<BillingDto> GetBilling()
        {
            var list = _context.Billings.Where(x => !x.IsDeleted).ToList();


            return list.Select(p => new BillingDto
            {
                ProductSelled = p.ProductSelled,
              ClientName = p.ClientName,
              ClientType = p.ClientType,
              Quantity = p.Quantity,
              Fecha = p.Fecha

            });
        }
    }
}