using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemVenta.Model.Entities;

namespace SystemVenta.api.BaseRepository.IGenericRepository
{
    public interface IClientRepository
    {
        Task<List<Client>> ObtenerclientsAsync();
        Task<Client> ObtenerclientAsync(int id);
        Task<Client> Agregar(Client Client);
        Task<bool> Actualizar(Client Client);
        Task<bool> Eliminar(int id);
    }
}
