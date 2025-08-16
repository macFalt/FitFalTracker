using FitFalTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitFalTracker.Persistance.Configuration;

public class ExerciseDefinitionConfiguration : IEntityTypeConfiguration<ExerciseDefinition>
{
    public void Configure(EntityTypeBuilder<ExerciseDefinition> builder)
    {
        builder.Property(e => e.Equipment)
            .HasConversion<string>();
    }
}