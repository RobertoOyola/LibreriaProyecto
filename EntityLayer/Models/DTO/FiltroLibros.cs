using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Models.DTO
{
    public class FiltroLibros
    {
        public string? Busqueda {  get; set; }
        public int? IdAutor { get; set; }
        public int? IdCategoria { get; set; }
    }
}
