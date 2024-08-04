using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Models.DTO
{
    public class InventarioDTO
    {
        public int IdLibros { get; set; }

        public int? TotalStock { get; set; }

        public string? Estado { get; set; }
    }
}
