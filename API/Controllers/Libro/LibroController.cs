using BusinessLayer.Services.Categoria;
using BusinessLayer.Services.Libro;
using EntityLayer.Models.DTO;
using EntityLayer.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Libro
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly ILibroServices _libroServices;
        private Response response = new();

        public LibroController(ILibroServices libroServices)
        {
            _libroServices = libroServices;
        }

        [HttpPost("ObtenerLibros")]
        public async Task<IActionResult> ObtenerLibroFiltro([FromBody] FiltroLibros filtroLibros)
        {
            var response = await _libroServices.ObtenerLibroFiltro(filtroLibros);

            if (response.Code == ResponseType.Error)
            {
                return BadRequest("No se pudo obtener los libros");
            }
            return Ok(response);
        }
    }
}
