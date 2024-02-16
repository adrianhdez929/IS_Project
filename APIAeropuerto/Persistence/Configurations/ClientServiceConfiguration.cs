using APIAeropuerto.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APIAeropuerto.Persistence.Configurations;

public class ClientServiceConfiguration : IEntityTypeConfiguration<ClientServicesPersistence>
{
    public void Configure(EntityTypeBuilder<ClientServicesPersistence> builder)
    {
        builder.HasKey(x => new {x.IdClient, x.IdService});
        builder.HasOne(x => x.Client)
            .WithMany(x => x.ClientServices)
            .HasForeignKey(x => x.IdClient);
        builder.HasOne(x => x.Service)
            .WithMany(x => x.ClientServices)
            .HasForeignKey(x => x.IdService);
    }
}