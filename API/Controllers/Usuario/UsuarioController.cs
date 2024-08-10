using BusinessLayer.Services.Autor;
using BusinessLayer.Services.Usuario;
using EntityLayer.Models.DTO;
using EntityLayer.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Usuario
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioServices _usuarioServices;
        private Response response = new();

        public UsuarioController(IUsuarioServices usuarioServices)
        {
            _usuarioServices = usuarioServices;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginUsuario loginUsuario)
        {
            var response = await _usuarioServices.LoginUsuario(loginUsuario);

            if (response.Code == ResponseType.Error)
            {
                return BadRequest("Credenciales equivocadas");
            }
            return Ok(response);
        }

        [HttpPost("InsertarUsuario")]
        public async Task<IActionResult> InsertarUsuario(UsuarioDTO usuarioDTO)
        {
            response = await _usuarioServices.InsertarUsuario(usuarioDTO);

            if (response.Code == ResponseType.Error)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
