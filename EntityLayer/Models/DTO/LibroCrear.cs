using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Models.DTO
{
    public class LibroCrear
    {
        public string? Nombre { get; set; }

        public string? AnioPublicacion { get; set; }

        public string? NombreAutor { get; set; }

        public int? TotalStock { get; set; }

        public string? DescripcionCategoria { get; set; }
    }
}
