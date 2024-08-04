using BusinessLayer.Services.Autor;
using DataLayer.Repositories.Autor;
using EntityLayer.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Autor
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IAutorServices _autorServices;
        private Response response = new();

        public AutorController(IAutorServices autorServices)
        {
            _autorServices = autorServices;
        }

        [HttpGet("ObtenerAutores")]
        public async Task<IActionResult> ObtenerAutores()
        {
            response = await _autorServices.ObtenerAutores();

            if (response.Code == ResponseType.Error)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
