using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SystemVenta.api.BaseRepository.IGenericRepository;
using SystemVenta.Bi.Dto;
using SystemVenta.Model.Entities;
using SystemVenta.Model.SystemVentaDb;

namespace SystemVenta.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly SystemVentaDbContext _context;

        public ProductsController(IProductRepository productRepository, IMapper mapper,SystemVentaDbContext context)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            this._context = context;
        }
        // GET: api/Products
        [HttpGet("[action]")]
        public IEnumerable<ProductDto> GetProduct()
        {
            var list =  _context.Products.Where( x => !x.IsDeleted).ToList();


            return list.Select(p => new ProductDto
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Precio = p.Precio
            });
        }

        // POST: api/Products
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateProduct([FromBody] ProductDto entityDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            Product product = new Product
            {
                Nombre = entityDto.Nombre,
                Precio = entityDto.Precio
            };
            _context.Products.Add(product);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
            return Ok(product);

        }

        // PUT: api/Products/5
        [HttpPut("[action]")]
        public async Task<IActionResult> EditProduct(ProductDto entityDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if(entityDto.Id <= 0)
            {
                return NotFound();
            }

            var result = await _context.Products.Where(x => x.Id == entityDto.Id).FirstOrDefaultAsync();

            result.Nombre = entityDto.Nombre;
            result.Precio = entityDto.Precio;

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
        public async Task<IActionResult> DeleteProduct(int id)
        {
          if(id == 0)
            {
                return BadRequest();
            }

            var product =  await _context.Products.Where(x => x.Id == id).FirstOrDefaultAsync();

                if (product is null)
                    return NotFound();


                product.IsDeleted = true;

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
