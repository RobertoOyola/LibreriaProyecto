using EntityLayer.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Models.DTO
{
    public class LibroDTO
    {
        public int IdLibro { get; set; }

        public string? Nombre { get; set; }

        public int? IdCategoria { get; set; }

        public int? IdAutor { get; set; }

        public string? AnioPublicacion { get; set; }

        public string? Estado { get; set; }
    }
}
