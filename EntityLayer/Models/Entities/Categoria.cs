﻿using System;
using System.Collections.Generic;

namespace EntityLayer.Models.Entities;

public partial class Categoria
{
    public int IdCategoria { get; set; }

    public string? DescripcionCategoria { get; set; }

    public string? Estado { get; set; }

    public virtual ICollection<Libro> Libros { get; set; } = new List<Libro>();
}
