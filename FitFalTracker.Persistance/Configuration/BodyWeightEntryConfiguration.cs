using FitFalTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FitFalTracker.Persistance.Configuration;

public class BodyWeightEntryConfiguration : IEntityTypeConfiguration<BodyWeightEntry>
{
    public void Configure(EntityTypeBuilder<BodyWeightEntry> builder)
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