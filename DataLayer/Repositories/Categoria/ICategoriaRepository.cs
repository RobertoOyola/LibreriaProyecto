using EntityLayer.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories.Categoria
{
    public interface ICategoriaRepository
    {
        public Task<Response> ObtenerCategorias();
    }
}
