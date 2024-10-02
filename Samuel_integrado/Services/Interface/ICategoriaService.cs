using System.Collections.Generic;
using System.Threading.Tasks;
using Samuel_integrado.Models;

namespace Samuel_integrado.Services.Interface
{
    public interface ICategoriaService
    {
        Task InsertarCategoria(string categoria, string descripcion, bool estado);
        Task ModificarCategoria(int idCategoria, string categoria, string descripcion, bool estado);
        Task<List<Categoria>> BuscarCategoriaPorId(int id);
        Task<List<Categoria>> ListarCategorias();
        Task EliminarCategoria(int id);
    }
}