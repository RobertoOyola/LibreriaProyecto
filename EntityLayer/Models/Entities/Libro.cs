using System;
using System.Collections.Generic;

namespace EntityLayer.Models.Entities;

public partial class Libro
{
    public int IdLibro { get; set; }

    public string? Nombre { get; set; }

    public int? IdCategoria { get; set; }

    public int? IdAutor { get; set; }

    public string? AnioPublicacion { get; set; }

    public string? Estado { get; set; }

    public virtual Autor? IdAutorNavigation { get; set; }

    public virtual Categoria? IdCategoriaNavigation { get; set; }

    public virtual Inventario? Inventario { get; set; }

    public virtual ICollection<PrestamosCabecera> PrestamosCabeceras { get; set; } = new List<PrestamosCabecera>();
}
