using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Practica20250311.AppWebMVC.Models;

public partial class Producto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio.")]
    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    [Required(ErrorMessage = "El precio es obligatorio.")]
   // [Range(typeof(decimal), "0.01", "99999999.99", ErrorMessage = "El precio debe estar entre 0.01 y 99999999.99")]
    public decimal Precio { get; set; }

    [Display(Name = "Marcas")]
    public int MarcaId { get; set; }

    [Display(Name = "Categorias")]
    public int CategoriaId { get; set; }

    public virtual Categoria? Categoria { get; set; } = null!;

    public virtual Marca? Marca { get; set; } = null!;
}
