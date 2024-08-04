using EntityLayer.Models.DTO;
using EntityLayer.Models.Entities;
using Riok.Mapperly.Abstractions;

namespace EntityLayer.Models.Mappers
{
    [Mapper]
    public partial class CategoriaMapper
    {
        public partial CategoriaDTO CategoriaToCategoriaDTO(Categoria categoria);
        public partial Categoria CategoriaToCategoriaDTO(CategoriaDTO categoriaDTO);
    }
}
