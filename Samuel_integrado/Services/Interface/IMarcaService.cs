using System.Collections.Generic;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Threading.Tasks;
using Samuel_integrado.Models;

namespace Samuel_integrador.Models
{
    public interface IMarcaService
    {
        Task<IEnumerable<Marca>> GetAllAsync();
        Task<Marca> GetByIdAsync(int id);
        Task CreateAsync(Marca marca);
        Task UpdateAsync(Marca marca);
        Task DeleteAsync(int id);
    }
}
