using DataLayer.Repositories.Estudiante;
using DataLayer.Repositories.Prestamo;
using EntityLayer.Models.DTO;
using EntityLayer.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Estudiante
{
    public class EstudianteServices : IEstudianteServices
    {
        private readonly IEstudianteRepository _estudianteRepository;
        private Response response = new();

        public EstudianteServices(IEstudianteRepository estudianteRepository)
        {
            _estudianteRepository = estudianteRepository;
        }

        public async Task<Response> InsertarEstudiante(EstudianteDTO estudianteDTO)
        {
            response = await _estudianteRepository.InsertarEstudiante(estudianteDTO);
            return response;
        }
    }
}
