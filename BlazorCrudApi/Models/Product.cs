using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorCrud.Models;

public class Product
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProductId { get; set; }

    [Required(ErrorMessage = "El nombre del producto es obligatorio.")]
    [MaxLength(255, ErrorMessage = "El nombre del producto no puede tener más de 255 caracteres.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "El precio es obligatorio.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor que 0.")]
    [Column(TypeName = "decimal(10,2)")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "La descripción es obligatoria.")]
    [MaxLength(1000, ErrorMessage = "La descripción no puede tener más de 1000 caracteres.")]
    public string Description { get; set; }

    [Required(ErrorMessage = "El stock es obligatorio.")]
    [Range(0, int.MaxValue, ErrorMessage = "El stock no puede ser negativo.")]
    public int Stock { get; set; }

    [Required(ErrorMessage = "El fabricante es obligatorio.")]
    [MaxLength(255, ErrorMessage = "El nombre del fabricante no puede tener más de 255 caracteres.")]
    public string Manufacturer { get; set; } // Fabricante en inglés

    [Required(ErrorMessage = "La fecha de fabricación es obligatoria.")]
    public DateTime ManufactureDate { get; set; } // FechaFabricacion en inglés

    [Required(ErrorMessage = "La fecha de vencimiento es obligatoria.")]
    public DateTime DueDate { get; set; } 
}
