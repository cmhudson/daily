using Microsoft.EntityFrameworkCore;
using daily.Models;

namespace daily.Models;

public class DailyContext : DbContext
{
    public DailyContext(DbContextOptions<DailyContext> options) : base(options)
    {

    }

    public DbSet<User> Users {get;set;} = null!;
    public DbSet<JournalEntry> JournalEntries { get; set; }  = null!;

}