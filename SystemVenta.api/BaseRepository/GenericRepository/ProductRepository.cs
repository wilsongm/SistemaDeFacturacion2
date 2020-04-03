using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemVenta.api.BaseRepository.IGenericRepository;
using SystemVenta.Model.Entities;
using SystemVenta.Model.SystemVentaDb;

namespace SystemVenta.api.BaseRepository.GenericRepository
{
    public class ProductRepository : IProductRepository
    {
        private SystemVentaDbContext _contexto;

        public ProductRepository(SystemVentaDbContext contexto)
        {
            _contexto = contexto;
        }
        public async Task<bool> Actualizar(Product product)
        {
            _contexto.Products.Attach(product);
            _contexto.Entry(product).State = EntityState.Modified;
            try
            {
                return await _contexto.SaveChangesAsync() > 0 ? true : false;
            }
            catch (Exception excepcion)
            {
                ;
            }
            return false;
        }

        public async Task<Product> Agregar(Product product)
        {
            _contexto.Products.Add(product);
            try
            {
                await _contexto.SaveChangesAsync();
            }
            catch (Exception excepcion)
            {
                ;
            }

            return product;
        }

        public async Task<bool> Eliminar(int id)
        {
            //Se realiza una eliminación suave, solamente inactivamos el product

            var product = await _contexto.Products
                                .SingleOrDefaultAsync(c => c.Id == id);

           
            _contexto.Products.Attach(product);
            _contexto.Entry(product).State = EntityState.Modified;

            try
            {
                return (await _contexto.SaveChangesAsync() > 0 ? true : false);
            }
            catch (Exception excepcion)
            {
                ;
            }
            return false;

        }

        public async Task<Product> ObtenerproductAsync(int id)
        {
            return await _contexto.Products
                               .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Product>> ObtenerproductsAsync()
        {
            return await _contexto.Products.OrderBy(u => u.Nombre)
                                            .ToListAsync();
        }

    }
}
