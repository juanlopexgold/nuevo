using Microsoft.AspNetCore.Mvc;
using Api.Interface; 
using Api.Model; 
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _productoService;

        public ProductoController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        [HttpGet("listar")]
        public async Task<IActionResult> ListarProductos()
        {
            var productos = await _productoService.GetAllProductos();
            return Ok(productos);
        }

        [HttpGet("buscar/{id}")]
        public async Task<IActionResult> BuscarProductoPorId(int id)
        {
            var producto = await _productoService.GetProductoById(id);
            if (producto == null)
            {
                return NotFound();
            }
            return Ok(producto);
        }

        [HttpPost("agregar")]
        public async Task<IActionResult> AgregarProducto([FromBody] ProductoEntities producto)
        {
            await _productoService.AddProducto(producto);
            return CreatedAtAction(nameof(BuscarProductoPorId), new { id = producto.idProducto }, producto);
        }

        [HttpPut("actualizar")]
        public async Task<IActionResult> ActualizarProducto([FromBody] ProductoEntities producto)
        {
            await _productoService.UpdateProducto(producto);
            return NoContent();
        }

        [HttpDelete("eliminar/{id}")]
        public async Task<IActionResult> EliminarProducto(int id)
        {
            await _productoService.DeleteProducto(id);
            return NoContent();
        }
    }
}