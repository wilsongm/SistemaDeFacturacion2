using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemVenta.Model.Entities;

namespace SystemVenta.api.BaseRepository.IGenericRepository
{
    interface IEntryRepository
    {
        Task<List<Entry>> ObtenerEntriesAsync();
        Task<Entry> ObtenerEntryAsync(int id);
        Task<Entry> Agregar(Entry Entry);
        Task<bool> Actualizar(Entry Entry);
        Task<bool> Eliminar(int id);
    }
}
