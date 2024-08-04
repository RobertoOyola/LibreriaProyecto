using System;
using System.Collections.Generic;

namespace EntityLayer.Models.Entities;

public partial class Estudiante
{
    public int IdEstudiante { get; set; }

    public string? Cedula { get; set; }

    public string? Correo { get; set; }

    public string? Contrasenia { get; set; }

    public string? Nombres { get; set; }

    public string? Estado { get; set; }

    public virtual ICollection<PrestamosCabecera> PrestamosCabeceras { get; set; } = new List<PrestamosCabecera>();
}
