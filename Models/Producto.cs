using System;
using System.Collections.Generic;

namespace EjercicioEFC.Models;

public partial class Producto
{
    public sbyte Id { get; set; }

    public string? NombreProducto { get; set; }

    public sbyte? IdCategoria { get; set; }

    public virtual Categoria? IdCategoriaNavigation { get; set; }
}
