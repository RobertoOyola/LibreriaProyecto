using EntityLayer.Models.DTO;
using EntityLayer.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories.Libro
{
    public interface ILibroRepository
    {
        public Task<Response> ObtenerLibroFiltro(FiltroLibros filtroLibros);

        public Task<Response> CrearLibro(LibroCrear libro);
    }
}
