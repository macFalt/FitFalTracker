using FitFalTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FitFalTracker.Application.Common.Interfaces;

public interface IFitFalDbContext
{
    DbSet<AppUser> AppUsers { get; set; }
    DbSet<Domain.Entities.Workout> Workouts { get; set; }
    DbSet<Domain.Entities.Exercise> Exercises { get; set; }
    DbSet<Domain.Entities.ExerciseDefinition> ExerciseDefinitions { get; set; }
    DbSet<ExerciseDetail> ExerciseDetails { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
}