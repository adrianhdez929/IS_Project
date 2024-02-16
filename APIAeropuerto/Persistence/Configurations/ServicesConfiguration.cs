using APIAeropuerto.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APIAeropuerto.Persistence.Configurations;

public class ServicesConfiguration : IEntityTypeConfiguration<ServicesPersistence>
{
    public void Configure(EntityTypeBuilder<ServicesPersistence> builder)
    {
        builder.HasOne(x => x.Installation)
            .WithMany(y => y.Services)
            .OnDelete(DeleteBehavior.Cascade);
    }
}