using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemVenta.Model.Entities;

namespace SystemVenta.api.BaseRepository.IGenericRepository
{
    interface IProviderRepository
    {
        Task<List<Provider>> ObtenerprovidersAsync();
        Task<Provider> ObtenerproviderAsync(int id);
        Task<Provider> Agregar(Provider Provider);
        Task<bool> Actualizar(Provider Provider);
        Task<bool> Eliminar(int id);
    }
}
