using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Samuel_integrado.Models;
namespace Interface
{
    public interface IModeloService
    {
        Task InsertarModelo(string nombre, string descripcion, bool estado);
        Task ModificarModelo(int idModelo, string nombre, string descripcion, bool estado);
        Task<List<Modelo>> BuscarModeloPorId(int id);
        Task<List<Modelo>> ListarModelos();
        Task EliminarModelo(int id);
    }
}