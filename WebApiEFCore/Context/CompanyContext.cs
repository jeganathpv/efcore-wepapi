namespace WebApiEFCore.Context;

using Microsoft.EntityFrameworkCore;
using WebApiEFCore.Models;

public class CompanyContext
    : DbContext
{
    public CompanyContext(DbContextOptions options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TeamView>()
            .ToView(nameof(TeamView))
            .HasKey(t => t.TeamName);
    }

    public DbSet<Employee> Employees { get; set; }

    public DbSet<Project> Projects { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<Team> Teams { get; set; }

    public DbSet<TeamView> TeamViews { get; set; }
}