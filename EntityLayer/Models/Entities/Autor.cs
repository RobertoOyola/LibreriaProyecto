﻿using System;
using System.Collections.Generic;

namespace EntityLayer.Models.Entities;

public partial class Autor
{
    public int IdAutor { get; set; }

    public string? NombreAutor { get; set; }

    public string? Estado { get; set; }

    public virtual ICollection<Libro> Libros { get; set; } = new List<Libro>();
}
