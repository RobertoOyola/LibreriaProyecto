using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Models.DTO
{
    public class PrestamosVista
    {
        public int IdPrestamo { get; set; }

        public int? IdEstudiante { get; set; }

        public int? IdLibro { get; set; }

        public DateTime? FechaPrestamo { get; set; }

        public DateTime? FechaEstimadaDevolucion { get; set; }

        public DateTime? FechaRealDevolucion { get; set; }

        public string? Estado { get; set; }

        public string? Nombre { get; set; }

        public string? Nombres { get; set; }
    }
}
