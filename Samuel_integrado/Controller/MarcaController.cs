using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Samuel_integrado.Models;
using Samuel_integrado.Services.Interface;

namespace Samuel_integrador.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcaController : ControllerBase
    {
        private readonly IMarcaService _marcaService;

        public MarcaController(IMarcaService marcaService)
        {
            _marcaService = marcaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Marca>>> GetMarcas()
        {
            var marcas = await _marcaService.GetAllAsync();
            return Ok(marcas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Marca>> GetMarca(int id)
        {
            var marca = await _marcaService.GetByIdAsync(id);
            if (marca == null)
            {
                return NotFound();
            }
            return Ok(marca);
        }

        [HttpPost]
        public async Task<ActionResult> CreateMarca(Marca marca)
        {
            await _marcaService.CreateAsync(marca);
            return CreatedAtAction(nameof(GetMarca), new { id = marca.IdMarca }, marca);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateMarca(int id, Marca marca)
        {
            if (id != marca.IdMarca)
            {
                return BadRequest();
            }
            await _marcaService.UpdateAsync(marca);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMarca(int id)
        {
            await _marcaService.DeleteAsync(id);
            return NoContent();
        }
    }
}
