using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Models.DTO
{
    public class CategoriaDTO
    {
        public int IdCategoria { get; set; }

        public string? DescripcionCategoria { get; set; }

        public string? Estado { get; set; }
    }
}
