﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SystemVenta.Bi.Dto;
using SystemVenta.Model.Entities;
using SystemVenta.Model.SystemVentaDb;

namespace SystemVenta.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StocksController : ControllerBase
    {
        private readonly SystemVentaDbContext _context;

        public StocksController(SystemVentaDbContext context)
        {
            _context = context;
        }
        // GET: api/Stocks
        [HttpGet("[action]")]
        public IEnumerable<StockDto> GetStock()
        {
            var list = _context.Stocks.Where(x => !x.IsDeleted).ToList();



            return list.Select(p => new StockDto
            {
                Id = p.Id,
                ProductName = p.ProductName,
                Quantity = p.Quantity,
                Date = p.Date

            });
        }


        // GET: api/Stocks/5


    }
}
