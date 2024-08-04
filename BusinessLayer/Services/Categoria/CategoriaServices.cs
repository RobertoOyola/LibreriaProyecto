using DataLayer.Repositories.Autor;
using DataLayer.Repositories.Categoria;
using EntityLayer.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Categoria
{
    public class CategoriaServices : ICategoriaServices
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private Response response = new();

        public CategoriaServices(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public async Task<Response> ObtenerCategorias()
        {
            response = await _categoriaRepository.ObtenerCategorias();
            return response;
        }
    }
}
