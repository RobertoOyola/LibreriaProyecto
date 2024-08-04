using EntityLayer.Models.DTO;
using EntityLayer.Models.Entities;
using Riok.Mapperly.Abstractions;

namespace EntityLayer.Models.Mappers
{
    [Mapper]
    public partial class PrestamosCabeceraMapper
    {
        public partial PrestamosCabeceraDTO PrestamosCabeceraToPrestamosCabeceraDTO(PrestamosCabecera prestamosCabecera);
        public partial PrestamosCabecera PrestamosCabeceraToPrestamosCabeceraDTO(PrestamosCabeceraDTO prestamosCabeceraDTO);
    }
}
