using System.Collections.Generic;
using System.Threading.Tasks;
using SystemVenta.Model.Entities;

namespace SystemVenta.api.BaseRepository.IGenericRepository
{
    public interface IProductRepository
    {
        Task<List<Product>> ObtenerproductsAsync();
        Task<Product> ObtenerproductAsync(int id);
        Task<Product> Agregar(Product producto);
        Task<bool> Actualizar(Product producto);
        Task<bool> Eliminar(int id);

    }
}
