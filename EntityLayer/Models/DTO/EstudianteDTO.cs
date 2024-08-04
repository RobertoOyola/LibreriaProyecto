using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Models.DTO
{
    public class EstudianteDTO
    {
        public int IdEstudiante { get; set; }

        public string? Cedula { get; set; }

        public string? Correo { get; set; }

        public string? Contrasenia { get; set; }

        public string? Nombres { get; set; }

        public string? Estado { get; set; }
    }
}
