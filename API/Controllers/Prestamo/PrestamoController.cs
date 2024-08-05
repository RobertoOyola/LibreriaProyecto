using BusinessLayer.Services.Prestamo;
using BusinessLayer.Services.Usuario;
using DataLayer.Repositories.Prestamo;
using EntityLayer.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Prestamo
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrestamoController : ControllerBase
    {
        private readonly IPrestamoServices _prestamoServices;
        private Response response = new();

        public PrestamoController(IPrestamoServices prestamoServices)
        {
            _prestamoServices = prestamoServices;
        }

        [HttpGet("ObtenerPrestamos")]
        public async Task<IActionResult> ObtenerPrestamos()
        {
            response = await _prestamoServices.ObtenerPrestamos();

            if (response.Code == ResponseType.Error)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

    }
}
