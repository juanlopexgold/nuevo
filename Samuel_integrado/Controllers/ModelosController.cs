using Interface;
using Microsoft.AspNetCore.Mvc;
using Samuel_integrado.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

    [Route("api/[controller]")]
    public class ModelosController : ControllerBase
    {
            private readonly IModeloService _modeloService;


        public ModelosController(IModeloService modeloService)
        {
            _modeloService = modeloService;
        }

        [HttpPost("insertar")]
        public async Task<IActionResult> InsertarModelo([FromBody] Modelo modelo)
        {
            if (modelo == null)
            {
                return BadRequest("El modelo es nulo.");
            }

            await _modeloService.InsertarModelo(modelo.Nombre, modelo.Descripcion, modelo.Estado);
            return Ok();
        }

        [HttpPut("modificar")]
        public async Task<IActionResult> ModificarModelo([FromBody] Modelo modelo)
        {
            if (modelo == null || modelo.IdModelo == null)
            {
                return BadRequest("El modelo es nulo o no tiene un ID.");
            }

            await _modeloService.ModificarModelo(modelo.IdModelo.Value, modelo.Nombre, modelo.Descripcion, modelo.Estado);
            return Ok();
        }

        [HttpGet("buscar/{id}")]
        public async Task<IActionResult> BuscarModeloPorId(int id)
        {
            var modelos = await _modeloService.BuscarModeloPorId(id);
            if (modelos == null || modelos.Count == 0)
            {
                return NotFound("No se encontró el modelo con el ID especificado.");
            }
            return Ok(modelos);
        }

    [HttpGet("listar")]
public async Task<IActionResult> ListarModelos()
{
    try
    {
        var modelos = await _modeloService.ListarModelos();
        return Ok(modelos);
    }
    catch (Exception ex)
    {
        return StatusCode(500, "Internal server error: " + ex.Message);
    }
}

        [HttpDelete("eliminar/{id}")]
        public async Task<IActionResult> EliminarModelo(int id)
        {
            await _modeloService.EliminarModelo(id);
            return Ok();
        }
    }
