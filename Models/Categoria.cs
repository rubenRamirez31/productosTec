using System;
using System.Collections.Generic;

namespace EjercicioEFC.Models;

public partial class Categoria
{
    public sbyte Id { get; set; }

    public string? NombreCategoria { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
