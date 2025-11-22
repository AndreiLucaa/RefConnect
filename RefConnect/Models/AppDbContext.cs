using Microsoft.EntityFrameworkCore;

namespace RefConnect.Models;

public class AppDbContext : DbContext
{
    public IEnumerable<object> userReferees;

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    // DbSet properties for each entity in the Models folder
    public DbSet<Championship> Champioships { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<GroupChat> GroupChats { get; set; }
    public DbSet<Match> Matches { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<userArbitru> UserArbitri { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // apply configurations in this assembly, or configure entities here
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}