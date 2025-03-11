using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Practica20250311.AppWebMVC.Models;

public partial class Producto
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public decimal Precio { get; set; }

    [Display(Name = "Marcas")]
    public int MarcaId { get; set; }

    [Display(Name = "Categorias")]
    public int CategoriaId { get; set; }

    public virtual Categoria Categoria { get; set; } = null!;

    public virtual Marca Marca { get; set; } = null!;
}
