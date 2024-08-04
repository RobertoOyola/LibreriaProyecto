using DataLayer.Repositories.Libro;
using DataLayer.Repositories.Usuario;
using EntityLayer.Models.DTO;
using EntityLayer.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Libro
{
    public class LibroServices : ILibroServices
    {
        private readonly ILibroRepository _libroRepository;
        private Response response = new();

        public LibroServices(ILibroRepository libroRepository)
        {
            _libroRepository = libroRepository;
        }

        public async Task<Response> ObtenerLibroFiltro(FiltroLibros filtroLibros)
        {
            response = await _libroRepository.ObtenerLibroFiltro(filtroLibros);
            return response;
        }
    }
}
