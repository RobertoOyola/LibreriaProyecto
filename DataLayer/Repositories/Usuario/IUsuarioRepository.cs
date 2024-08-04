using EntityLayer.Models.DTO;
using EntityLayer.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories.Usuario
{
    public interface IUsuarioRepository
    {
        public Task<Response> LoginUsuario(LoginUsuario loginUsuario);
    }
}
