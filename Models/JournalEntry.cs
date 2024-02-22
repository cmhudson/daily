using System.ComponentModel.DataAnnotations;
using System.Security.Permissions;

namespace daily.Models;

public class JournalEntry
{
    public long Id {get; set; }
    [StringLength(200)]
    public string? Title { get; set; }
    [StringLength(5000)]
    public string? Body { get; set; }
    [StringLength(1000)]
    public string? Supplemental {get; set; }

    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }

    //public int? UserId { get; set; }
    public User? User {get; set; }
    
    
}