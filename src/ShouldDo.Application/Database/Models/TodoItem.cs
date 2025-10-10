using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShouldDo.Application.Database.Models;

public class TodoItem
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    
    [Required]
    [MaxLength(150)]
    public required string Title { get; set; }
    
    [MaxLength(500)]
    public string Description { get; set; } = string.Empty;
}