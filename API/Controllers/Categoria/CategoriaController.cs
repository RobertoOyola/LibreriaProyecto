using BusinessLayer.Services.Autor;
using BusinessLayer.Services.Categoria;
using EntityLayer.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Categoria
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaServices _categoriaServices;
        private Response response = new();

        public CategoriaController(ICategoriaServices categoriaServices)
        {
            _categoriaServices = categoriaServices;
        }

        [HttpGet("ObtenerCategorias")]
        public async Task<IActionResult> ObtenerCategorias()
        {
            response = await _categoriaServices.ObtenerCategorias();

            if (response.Code == ResponseType.Error)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
