using EntityLayer.Models.DTO;
using EntityLayer.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Estudiante
{
    public interface IEstudianteServices
    {
        public Task<Response> InsertarEstudiante(EstudianteDTO estudianteDTO);
    }
}
