using System.Reflection;
using FitFalTracker.Domain.Common;
using FitFalTracker.Domain.Entities;
using FitFalTracker.Domain.ValueObjects;
//using FitFalTracker.Persistance.SeedData;
using Microsoft.EntityFrameworkCore;

namespace FitFalTracker.Persistance;

public class FitFalDbContext : DbContext
{
    public FitFalDbContext(DbContextOptions<FitFalDbContext> options) : base(options)
    {
  
    }
    
    public DbSet<AppUser> AppUsers { get; set; }
    public DbSet<Workout> Workouts { get; set; }
    public DbSet<Exercise> Exercises { get; set; }
    public DbSet<ExerciseDefinition> ExerciseDefinitions { get; set; }
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
        //modelBuilder.SeedDataAdmin();
        
        
        //modelBuilder.Entity<AppUser>().OwnsOne(p => p.UserName);
    }


    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.Created = DateTime.Now;
                    entry.Entity.CreatedBy = string.Empty;
                    entry.Entity.StatusId = 1;
                    break;
                case EntityState.Modified:
                    entry.Entity.Modified = DateTime.Now;
                    entry.Entity.ModifiedBy = string.Empty;
                    break;
                case EntityState.Deleted:
                    entry.Entity.StatusId = 0;
                    entry.Entity.ModifiedBy = string.Empty;
                    entry.Entity.Modified = DateTime.Now;
                    entry.Entity.Inactivated=DateTime.Now;
                    entry.Entity.InactivatedBy = string.Empty;
                    entry.State = EntityState.Modified;
                    break;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }
}