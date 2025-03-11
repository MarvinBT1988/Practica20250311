using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practica20250311.AppWebMVC.Models;

public partial class Usuario
{
    public int Id { get; set; }
    [Required(ErrorMessage = "El nombre es obligatorio.")]
    public string Nombre { get; set; } = null!;
    [Required(ErrorMessage = "El password es obligatorio.")]
    [DataType(DataType.Password)]
    [StringLength(40, MinimumLength = 5, ErrorMessage = "El passowrd debe tener entre 5 y 50 caracteres.")]
    public string Password { get; set; } = null!;
   
    [Required(ErrorMessage = "El Email es obligatorio.")]
    [EmailAddress(ErrorMessage = "El correo electrónico no tiene un formato válido.")]
    public string Email { get; set; } = null!;

    public DateTime? FechaRegistro { get; set; }

    public DateTime? UltimoInicioSesion { get; set; } = DateTime.Now;

    public byte? Estatus { get; set; } = 1;

    private string strEstatus;
    [NotMapped]
    public string StrEstatus
    {
        get {
            if (Estatus == 1)
                strEstatus = "Activo";
            else if (Estatus == 2)
                strEstatus = "Inactivo";
            return strEstatus;
        }
        set { strEstatus = value; }
    }
    [NotMapped]
    [StringLength(40, MinimumLength = 5, ErrorMessage = "El password debe tener entre 5 y 50 caracteres.")]
    [Display(Name = "Confirmar Password")]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Las contraseñas no coinciden.")]
    public string? ConfirmarPassword { get; set; } = null!;
}
