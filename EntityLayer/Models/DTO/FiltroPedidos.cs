using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Models.DTO
{
    public class FiltroPedidos
    {
        public int? IdEstudiante { get; set; }

        public int? IdLibro { get; set; }

        public DateTime? FechaEstimadaDevolucion { get; set; }

    }
}
