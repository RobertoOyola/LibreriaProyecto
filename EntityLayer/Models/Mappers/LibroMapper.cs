using EntityLayer.Models.DTO;
using EntityLayer.Models.Entities;
using Riok.Mapperly.Abstractions;

namespace EntityLayer.Models.Mappers
{
    [Mapper]
    public partial class LibroMapper
    {
        public partial LibroDTO LibroToLibroDTO(Libro libro);
        public partial Libro LibroToLibroDTO(LibroDTO libroDTO);
    }
}
