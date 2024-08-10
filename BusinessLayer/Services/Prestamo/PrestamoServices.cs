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

        public async Task<Response> ObtenerPrestamos(string? busqueda)
        {
            response = await _prestamoRepository.ObtenerPrestamos(busqueda);
            return response;
        }

        public async Task<Response> InsertarPrestamos(PrestamoDTO prestamoDTO)
        {
            response = await _prestamoRepository.InsertarPrestamos(prestamoDTO);
            return response;
        }

        public async Task<Response> ConfirmarPrestamos(int idPrestamo)
        {
            response = await _prestamoRepository.ConfirmarPrestamos(idPrestamo);
            return response;
        }
    }
}
