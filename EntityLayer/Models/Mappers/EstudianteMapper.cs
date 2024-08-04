using EntityLayer.Models.DTO;
using EntityLayer.Models.Entities;
using Riok.Mapperly.Abstractions;

namespace EntityLayer.Models.Mappers
{
    [Mapper]
    public partial class EstudianteMapper
    {
        public partial EstudianteDTO EstudianteToEstudianteDTO(Estudiante estudiante);
        public partial Estudiante EstudianteToEstudianteDTO(EstudianteDTO estudianteDTO);
    }
}
