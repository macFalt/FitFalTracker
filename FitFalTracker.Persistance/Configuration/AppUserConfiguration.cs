using FitFalTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitFalTracker.Persistance.Configuration;

public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.OwnsOne(p => p.FullName).Property(p => p.FirstName).HasColumnName("FirstName").IsRequired();
        builder.OwnsOne(p => p.FullName).Property(p => p.LastName).HasColumnName("LastName").IsRequired();
    }
}