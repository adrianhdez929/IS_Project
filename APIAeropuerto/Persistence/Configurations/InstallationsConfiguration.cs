using APIAeropuerto.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APIAeropuerto.Persistence.Configurations;

public class InstallationsConfiguration : IEntityTypeConfiguration<InstallationsPersistence>
{
    public void Configure(EntityTypeBuilder<InstallationsPersistence> builder)
    {
        builder.HasOne(x => x.Airport)
            .WithMany(y => y.Installations)
            .OnDelete(DeleteBehavior.Cascade);
    }
}