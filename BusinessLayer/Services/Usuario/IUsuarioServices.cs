using EntityLayer.Models.DTO;
using EntityLayer.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Usuario
{
    public interface IUsuarioServices
    {
        public Task<Response> LoginUsuario(LoginUsuario loginUsuario);

        public Task<Response> InsertarUsuario(UsuarioDTO usuarioDTO);

    }
}
