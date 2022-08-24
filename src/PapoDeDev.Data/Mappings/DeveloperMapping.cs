using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PapoDeDev.Domain.Entities;

namespace PapoDeDev.Data.Mappings
{
    public class DeveloperMapping : IEntityTypeConfiguration<Developer>
    {
        void IEntityTypeConfiguration<Developer>.Configure(EntityTypeBuilder<Developer> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasColumnType("varchar(32)");
            builder.Property(x => x.Company).IsRequired().HasColumnType("varchar(32)");
            builder.Property(x => x.Role).IsRequired().HasColumnType("varchar(32)");

            builder.ToTable("Developer");
        }
    }
}
