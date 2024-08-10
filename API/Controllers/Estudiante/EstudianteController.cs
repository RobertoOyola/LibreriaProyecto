using BusinessLayer.Services.Estudiante;
using BusinessLayer.Services.Libro;
using EntityLayer.Models.DTO;
using EntityLayer.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Estudiante
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudianteController : ControllerBase
    {
        private readonly IEstudianteServices _estudianteServices;
        private Response response = new();

        public EstudianteController(IEstudianteServices estudianteServices)
        {
            _estudianteServices = estudianteServices;
        }

        [HttpPost("InsertarEstudiante")]
        public async Task<IActionResult> InsertarEstudiante(EstudianteDTO estudianteDTO)
        {
            response = await _estudianteServices.InsertarEstudiante(estudianteDTO);

            if (response.Code == ResponseType.Error)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
