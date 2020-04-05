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
    public class ClientRepository : IClientRepository
    {
        private SystemVentaDbContext _contexto;

        public ClientRepository(SystemVentaDbContext contexto)
        {
            _contexto = contexto;
        }
        public async Task<bool> Actualizar(Client Client)
        {
            _contexto.Clients.Attach(Client);
            _contexto.Entry(Client).State = EntityState.Modified;
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

        public async Task<Client> Agregar(Client Client)
        {
            _contexto.Clients.Add(Client);
            try
            {
                await _contexto.SaveChangesAsync();
            }
            catch (Exception excepcion)
            {
                ;
            }

            return Client;
        }

        public async Task<bool> Eliminar(int id)
        {
            //Se realiza una eliminación suave, solamente inactivamos el product

            var Client = await _contexto.Clients
                                .SingleOrDefaultAsync(c => c.Id == id);


            _contexto.Clients.Attach(Client);
            _contexto.Entry(Client).State = EntityState.Modified;

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

        public async Task<Client> ObtenerclientAsync(int id)
        {
            return await _contexto.Clients
                               .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Client>> ObtenerclientsAsync()
        {
            return await _contexto.Clients.OrderBy(u => u.Nombre)
                                            .ToListAsync();
        }

    }
    
}
