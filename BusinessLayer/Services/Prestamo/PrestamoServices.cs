using DataLayer.Repositories.Prestamo;
using DataLayer.Repositories.Usuario;
using EntityLayer.Models.DTO;
using EntityLayer.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Prestamo
{
    public class PrestamoServices : IPrestamoServices
    {
        private readonly IPrestamoRepository _prestamoRepository;
        private Response response = new();

        public PrestamoServices(IPrestamoRepository prestamoRepository)
        {
            _prestamoRepository = prestamoRepository;
        }

        public async Task<Response> ObtenerPrestamos()
        {
            response = await _prestamoRepository.ObtenerPrestamos();
            return response;
        }
    }
}
