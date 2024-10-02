using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Model; 

namespace Api.Interface
{
    public interface IProductoService
    {
        Task<IEnumerable<ProductoEntities>> GetAllProductos();
        Task<ProductoEntities> GetProductoById(int idProducto);
        Task AddProducto(ProductoEntities producto);
        Task UpdateProducto(ProductoEntities producto);
        Task DeleteProducto(int idProducto);
    }
}
