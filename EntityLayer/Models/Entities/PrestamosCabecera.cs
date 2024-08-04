using System;
using System.Collections.Generic;

namespace EntityLayer.Models.Entities;

public partial class PrestamosCabecera
{
    public int IdPrestamo { get; set; }

    public int? IdEstudiante { get; set; }

    public int? IdLibro { get; set; }

    public DateTime? FechaPrestamo { get; set; }

    public DateTime? FechaEstimadaDevolucion { get; set; }

    public DateTime? FechaRealDevolucion { get; set; }

    public string? Estado { get; set; }

    public virtual Estudiante? IdEstudianteNavigation { get; set; }

    public virtual Libro? IdLibroNavigation { get; set; }
}
