using System.ComponentModel.DataAnnotations;

namespace PersonalManagementApp.Infrastructure.Data.Models.Notes;

public class Note
{
    [Key]
    public string Id { get; set; }

    [Required]
    [StringLength(20)]
    public string Title { get; set; }
    
    [Required]
    [StringLength(500)]
    public string Content { get; set; }
    
    [Required]
    public bool Favourited { get; set; }
}