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
    public class ProviderRepository : IProviderRepository
    {
        private SystemVentaDbContext _contexto;

        public ProviderRepository(SystemVentaDbContext contexto)
        {
            _contexto = contexto;
        }
        public async Task<bool> Actualizar(Provider Provider)
        {
            _contexto.Providers.Attach(Provider);
            _contexto.Entry(Provider).State = EntityState.Modified;
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

        public async Task<Provider> Agregar(Provider Provider)
        {
            _contexto.Providers.Add(Provider);
            try
            {
                await _contexto.SaveChangesAsync();
            }
            catch (Exception excepcion)
            {
                ;
            }

            return Provider;
        }

        public async Task<bool> Eliminar(int id)
        {
            //Se realiza una eliminación suave, solamente inactivamos el Provider

            var Provider = await _contexto.Providers
                                .SingleOrDefaultAsync(c => c.Id == id);


            _contexto.Providers.Attach(Provider);
            _contexto.Entry(Provider).State = EntityState.Modified;

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

        public async Task<Provider> ObtenerproviderAsync(int id)
        {
            return await _contexto.Providers
                               .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Provider>> ObtenerprovidersAsync()
        {
            return await _contexto.Providers.OrderBy(u => u.Nombre)
                                            .ToListAsync();
        }

    }

}
