using System.ComponentModel.DataAnnotations;

namespace PersonalManagementApp.Core.Models.Notes;

public class NoteModel
{
    public string id { get; set; }

    [StringLength(20)]
    public string title { get; set; }
    
    [StringLength(500)]
    public string content { get; set; }

    public bool favourited;
}