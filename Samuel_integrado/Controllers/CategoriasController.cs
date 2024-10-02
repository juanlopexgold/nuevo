using Microsoft.AspNetCore.Mvc;
using Samuel_integrado.Models;
using Samuel_integrado.Services.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class CategoriasController : ControllerBase
{
    private readonly ICategoriaService _categoriaService;

    public CategoriasController(ICategoriaService categoriaService)
    {
        _categoriaService = categoriaService;
    }

    [HttpPost("insertar")]
    public async Task<IActionResult> InsertarCategoria([FromBody] Categoria categoria)
    {
        if (categoria == null)
        {
            return BadRequest("Categoria is null.");
        }

        await _categoriaService.InsertarCategoria(categoria.Categorias, categoria.Descripcion, categoria.Estado);
        return Ok();
    }

    [HttpPut("modificar")]
    public async Task<IActionResult> ModificarCategoria([FromBody] Categoria categoria)
    {
        if (categoria == null)
        {
            return BadRequest("Categoria is null.");
        }

        await _categoriaService.ModificarCategoria(categoria.IdCategoria.Value, categoria.Categorias, categoria.Descripcion, categoria.Estado);
        return Ok();
    }

    [HttpGet("buscar/{id}")]
    public async Task<IActionResult> BuscarCategoriaPorId(int id)
    {
        var categorias = await _categoriaService.BuscarCategoriaPorId(id);
        return Ok(categorias);
    }

    [HttpGet("listar")]
    public async Task<IActionResult> ListarCategorias()
    {
        var categorias = await _categoriaService.ListarCategorias();
        return Ok(categorias);
    }

    [HttpDelete("eliminar/{id}")]
    public async Task<IActionResult> EliminarCategoria(int id)
    {
        await _categoriaService.EliminarCategoria(id);
        return Ok();
    }
}