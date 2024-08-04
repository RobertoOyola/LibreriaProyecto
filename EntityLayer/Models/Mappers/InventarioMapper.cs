using EntityLayer.Models.DTO;
using EntityLayer.Models.Entities;
using Riok.Mapperly.Abstractions;

namespace EntityLayer.Models.Mappers
{
    [Mapper]
    public partial class InventarioMapper
    {
        public partial InventarioDTO InventarioToInventarioDTO(Inventario inventario);
        public partial Inventario InventarioToInventarioDTO(InventarioDTO inventarioDTO);
    }
}
