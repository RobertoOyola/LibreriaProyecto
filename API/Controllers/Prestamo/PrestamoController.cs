using BusinessLayer.Services.Prestamo;
using BusinessLayer.Services.Usuario;
using DataLayer.Repositories.Prestamo;
using EntityLayer.Models.DTO;
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
        public async Task<IActionResult> ObtenerPrestamos(string? busqueda)
        {
            var response = await _prestamoServices.ObtenerPrestamos(busqueda);

            if (response.Code == ResponseType.Error)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPost("InsertarPrestamos")]
        public async Task<IActionResult> InsertarPrestamos(PrestamoDTO prestamoDTO)
        {
            response = await _prestamoServices.InsertarPrestamos(prestamoDTO);

            if (response.Code == ResponseType.Error)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPut("ConfirmarPrestamos")]
        public async Task<IActionResult> ConfirmarPrestamos([FromBody] int idPrestamo)
        {
            var response = await _prestamoServices.ConfirmarPrestamos(idPrestamo);

            if (response.Code == ResponseType.Error)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

    }
}
