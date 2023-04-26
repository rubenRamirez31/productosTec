using System;
using System.Collections.Generic;

namespace EjercicioEFC.Models;

public partial class Persona
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public short? Edad { get; set; }

    public string? Ocupacion { get; set; }
}
