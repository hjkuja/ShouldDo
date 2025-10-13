using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShouldDo.Application.Database.Models;

public class TodoItem
{
    public const int MaxTitleLength = 15;
    public const int MaxDescriptionLength = 30;

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    
    [Required]
    [MaxLength(MaxTitleLength)]
    public required string Title { get; set; }
    
    [MaxLength(MaxDescriptionLength)]
    public string Description { get; set; } = string.Empty;
}