using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class MaterialConfigurations : ExtendedBaseModelConfiguration<Material>
    {
        public override void Configure(EntityTypeBuilder<Material> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Name).HasColumnType("varchar(80)");
        }
    }
}
