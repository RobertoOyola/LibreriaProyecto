using DataLayer.Repositories.Autor;
using DataLayer.Repositories.Usuario;
using EntityLayer.Models.DTO;
using EntityLayer.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Usuario
{
    public class UsuarioServices : IUsuarioServices
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private Response response = new();

        public UsuarioServices(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<Response> LoginUsuario(LoginUsuario loginUsuario)
        {
            response = await _usuarioRepository.LoginUsuario(loginUsuario);
            return response;
        }

        public async Task<Response> InsertarUsuario(UsuarioDTO usuarioDTO)
        {
            response = await _usuarioRepository.InsertarUsuario(usuarioDTO);
            return response;
        }
    }
}
