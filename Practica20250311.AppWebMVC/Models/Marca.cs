﻿using System;
using System.Collections.Generic;

namespace Practica20250311.AppWebMVC.Models;

public partial class Marca
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
