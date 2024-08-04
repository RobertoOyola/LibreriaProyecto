using EntityLayer.Models.DTO;
using EntityLayer.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Libro
{
    public interface ILibroServices
    {
        public Task<Response> ObtenerLibroFiltro(FiltroLibros filtroLibros);
    }
}
