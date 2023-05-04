using System;
using System.Collections.Generic;

namespace EjercicioEFC.Models;

public partial class Construccione
{
    public int Id { get; set; }

    public string? Construccion { get; set; }

    public string? Descripcion { get; set; }

    public DateTime? FechaInicio { get; set; }

    public byte[]? Imagen { get; set; }
}
