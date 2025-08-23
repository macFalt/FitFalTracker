using FitFalTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitFalTracker.Persistance.Configuration;

public class ExerciseDetailConfiguration : IEntityTypeConfiguration<ExerciseDetail>
{
    public void Configure(EntityTypeBuilder<ExerciseDetail> builder)
    {
        builder.OwnsOne(p => p.Weight, w =>
        {
            w.Property(p => p.Value)
                .HasColumnName("Weight")
                .IsRequired();

            w.Property(p => p.WeightEnum)
                .HasColumnName("WeightEnum")
                .HasConversion<string>()
                .IsRequired();
        });
    }
}