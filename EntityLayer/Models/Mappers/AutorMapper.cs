using EntityLayer.Models.DTO;
using EntityLayer.Models.Entities;
using Riok.Mapperly.Abstractions;

namespace EntityLayer.Models.Mappers
{
    [Mapper]
    public partial class AutorMapper
    {
        public partial AutorDTO AutorToAutorDTO(Autor autor);
        public partial Autor AutorToAutorDTO(AutorDTO autorDTO);
    }
}
