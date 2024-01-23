using System.Security.Permissions;

namespace daily.Models;

public class User
{
    public long Id {get; set; }
    public required string Email {get; set;}
    public string? Name {get; set; }
    public DateTime CreatedAt {get; set;}
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public DateTime? DisabledAt { get; set; }

    public ICollection<JournalEntry>? JournalEntries {get; set; } = [];
}