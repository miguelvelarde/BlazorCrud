using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorCrud.Models;

public class Book
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required(ErrorMessage = "El título es obligatorio.")]
    [MaxLength(255, ErrorMessage = "El título no puede tener más de 255 caracteres.")]
    public string Title { get; set; }

    [Required(ErrorMessage = "La descripción es obligatoria.")]
    [MaxLength(1000, ErrorMessage = "La descripción no puede tener más de 1000 caracteres.")]
    public string Description { get; set; }

    [Required(ErrorMessage = "El autor es obligatorio.")]
    [MaxLength(255, ErrorMessage = "El nombre del autor no puede tener más de 255 caracteres.")]
    public string Author { get; set; }

    [Required(ErrorMessage = "El número de páginas es obligatorio.")]
    [Range(1, int.MaxValue, ErrorMessage = "El número de páginas debe ser mayor que 0.")]
    public int Pages { get; set; }

    [Required(ErrorMessage = "El precio es obligatorio.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor que 0.")]
    [Column(TypeName = "decimal(10,2)")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "La fecha de creación es obligatoria.")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreationDate { get; set; } = DateTime.UtcNow;
}
