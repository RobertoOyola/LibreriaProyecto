using System;
using System.Collections.Generic;

namespace EntityLayer.Models.Entities;

public partial class Inventario
{
    public int IdLibros { get; set; }

    public int? TotalStock { get; set; }

    public string? Estado { get; set; }

    public virtual Libro IdLibrosNavigation { get; set; } = null!;
}
