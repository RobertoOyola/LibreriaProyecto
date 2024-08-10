using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Models.DTO
{
    public class PrestamoDTO
    {
        public int? IdLibro { get; set; }

        public DateTime? FechaEstimadaDevolucion { get; set; }

        public string? Correo { get; set; }

        public string? Contrasenia { get; set; }
    }
}
