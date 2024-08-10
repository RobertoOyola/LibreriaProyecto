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

        [HttpPost("CrearLibro")]
        public async Task<IActionResult> CrearLibro(LibroCrear libro)
        {
            response = await _libroServices.CrearLibro(libro);

            if (response.Code == ResponseType.Error)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
