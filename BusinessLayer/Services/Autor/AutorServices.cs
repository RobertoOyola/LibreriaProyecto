using DataLayer.Repositories.Autor;
using EntityLayer.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Autor
{
    public class AutorServices : IAutorServices
    {
        private readonly IAutorRepository _autorRepository;
        private Response response = new();

        public AutorServices(IAutorRepository autorRepository)
        {
            _autorRepository = autorRepository;
        }

        public async Task<Response> ObtenerAutores()
        {
            response = await _autorRepository.ObtenerAutores();
            return response;
        }
    }
}
