using Microsoft.EntityFrameworkCore;

namespace daily.Models;

public class DailyContext : DbContext
{
    public DailyContext(DbContextOptions<DailyContext> options) : base(options)
    {

    }

    public DbSet<JournalEntry> JournalEntries { get; set; }  = null!;
}